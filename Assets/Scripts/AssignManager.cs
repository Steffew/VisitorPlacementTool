using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssignManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;
    [SerializeField] private VisitorManager visitorManager;

    //public void AssignVisitors() /// TODO: Refactor or delete this method, as there should be a first come first serve system.
    //{
    //    List<Section> sections = layoutManager.GetSections();

    //    foreach (Visitor visitor in visitorManager.GetQueue())
    //    {
    //        foreach (Section section in sections)
    //        {
    //            int firstRow = section.Seats.Count / section.Rows;

    //            foreach (Seat seat in section.Seats)
    //            {
    //                if (seat.Occupant == null)
    //                {
    //                    if (seat.Id <= firstRow && !visitor.IsAdult)
    //                    {
    //                        seat.SetOccupant(visitor);
    //                        visitor.MoveTo(seat);
    //                    }
    //                    else if (seat.Id > firstRow && visitor.IsAdult)
    //                    {
    //                        seat.SetOccupant(visitor);
    //                        visitor.MoveTo(seat);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    public void AssignFromQueue()
    {
        List<Group> queue = visitorManager.GetQueue();

        foreach (Group group in queue)
        {
            AssignGroup(group);
        }
    }

    public void AssignGroup(Group group)
    {
        foreach (Section section in layoutManager.GetSections())
        {
            int childrenCount = group.GetChildrenCount();
            int groupSize = group.GetVisitors().Count;
            int seatsPerRow = section.Columns;
            bool firstAdultAssigned = false;

            if (CanGroupFit(group, section) || (childrenCount == 0 && section.AvailableSeats.Count >= groupSize))
            {
                foreach (Visitor visitor in group.GetVisitors())
                {
                    if (!visitor.IsAdult || (childrenCount > 0 && !firstAdultAssigned))
                    {
                        foreach (Seat seat in section.AvailableSeats)
                        {
                            if (seat.Id <= seatsPerRow) // todo TIMO: Maybe use a different name than ID (seat number maybe? Like in the expensive cinemas). Is this check still necessary even :)?
                            {
                                section.OccupySeat(seat, visitor);
                                visitor.MoveTo(seat);

                                section.AvailableSeats.Remove(seat); // TODO: does this work? won't this throw modified list exception?

                                if (visitor.IsAdult)
                                {
                                    firstAdultAssigned = true;
                                }
                                break;
                            }
                        }
                    }
                }


                if (childrenCount == 0 || firstAdultAssigned)
                {
                    var visitorsAdultNotPlaced = group.GetVisitors().Where(v => v.IsAdult && !section.Seats.Any(s => s.Occupant == v)).ToList();
                    foreach (Visitor visitor in visitorsAdultNotPlaced)
                    {
                        foreach (Seat seat in section.AvailableSeats)
                        {
                            if (seat.Id > seatsPerRow && seat.Id <= 2 * seatsPerRow)
                            {
                                section.OccupySeat(seat, visitor);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public bool CanGroupFit(Group group, Section section)
    {
        int seatsPerRow = section.Columns;
        int childrenCount = group.GetChildrenCount();
        int requiredSeats = childrenCount + 1; // Children + 1 adult

        List<Seat> firstRowSeats = section.Seats.GetRange(0, seatsPerRow);

        for (int i = 0; i <= firstRowSeats.Count - requiredSeats; i++)
        {
            bool canFit = true;
            for (int j = i; j < i + requiredSeats; j++)
            {
                if (firstRowSeats[j].Occupant != null)
                {
                    canFit = false;
                    break;
                }
            }
            if (canFit)
            {
                return true;
            }
        }
        return false;
    }
}