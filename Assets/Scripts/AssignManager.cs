using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssignManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;
    [SerializeField] private VisitorManager visitorManager;

    public void AssignGroup(Group group)
    {
        foreach (Section section in layoutManager.GetSections())
        {
            if (CanGroupFit(group, section, singleRowAssignment: true))
            {
                var unoccupiedSeats = section.Seats.Where(seat => seat.Occupant == null).ToList();
                int seatIndex = 0;

                foreach (Visitor visitor in group.Visitors)
                {
                    if (seatIndex < unoccupiedSeats.Count)
                    {
                        Seat seatToAssign = unoccupiedSeats[seatIndex];
                        seatToAssign.SetOccupant(visitor);
                        visitor.MoveTo(seatToAssign);
                        seatIndex++;
                    }
                }
            }
        }
    }

    public bool CanGroupFit(Group group, Section section, bool singleRowAssignment = false)
    {
        int amountOfAdultsNecessary = 1;
        int childrenCount = group.GetChildrenCount();
        int requiredSeats = childrenCount + amountOfAdultsNecessary;
        int availableSeats = section.AvailableSeats.Count;
        int seatsPerRow = section.Seats.Count / section.Rows;

        if (!singleRowAssignment && requiredSeats >= availableSeats)
        {
            return true;
        }

        if (singleRowAssignment && requiredSeats >= availableSeats)
        {
            int successiveSeats = 0;

            foreach (Seat seat in section.AvailableSeats)
            {
                if (seat.ColumnNumber <= seatsPerRow) // Todo: This will always be true, but I'm leaving it in for now. I need to add more variables to the Seat class in order to make this work.
                {
                    successiveSeats++;
                }

                return (successiveSeats == requiredSeats);
            }
        }

        return false;
    }

    public void AssignFromQueue()
    {
        List<Group> queue = visitorManager.GetQueue();

        foreach (Group group in queue)
        {
            AssignGroup(group);
        }
    }

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

    //public void AssignGroup(Group group)
    //{
    //    foreach (Section section in layoutManager.GetSections())
    //    {
    //        int childrenCount = group.GetChildrenCount();
    //        int groupSize = group.GetVisitors().Count;
    //        int seatsPerRow = section.Columns;
    //        bool firstAdultAssigned = false;

    //        if (CanGroupFit(group, section) || (childrenCount == 0 && section.AvailableSeats.Count >= groupSize))
    //        {
    //            foreach (Visitor visitor in group.GetVisitors())
    //            {
    //                if (!visitor.IsAdult || (childrenCount > 0 && !firstAdultAssigned))
    //                {
    //                    foreach (Seat seat in section.AvailableSeats)
    //                    {
    //                        if (seat.Id <= seatsPerRow) // todo TIMO: Maybe use a different name than ID (seat number maybe? Like in the expensive cinemas). Is this check still necessary even :)?
    //                        {
    //                            section.OccupySeat(seat, visitor);
    //                            visitor.MoveTo(seat);


    //                            if (visitor.IsAdult)
    //                            {
    //                                firstAdultAssigned = true;
    //                            }
    //                            break;
    //                        }

    //                        section.AvailableSeats.Remove(seat); // todo: Check for modified list exception.
    //                    }
    //                }
    //            }

    //            if (childrenCount == 0 || firstAdultAssigned)
    //            {
    //                var visitorsAdultNotPlaced = group.GetVisitors().Where(v => v.IsAdult && !section.Seats.Any(s => s.Occupant == v)).ToList();
    //                foreach (Visitor visitor in visitorsAdultNotPlaced)
    //                {
    //                    foreach (Seat seat in section.AvailableSeats)
    //                    {
    //                        if (seat.Id > seatsPerRow && seat.Id <= 2 * seatsPerRow)
    //                        {
    //                            section.OccupySeat(seat, visitor);
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}