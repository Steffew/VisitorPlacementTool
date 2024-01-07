using System.Collections.Generic;
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

    public void AssignGroup(Group group)
    {
        foreach (Section section in layoutManager.GetSections())
        {
            if (CanGroupFit(group, section) || (group.GetChildrenCount() == 0 && section.AvailableSeats.Count >= group.GetVisitors().Count))
            {
                bool firstAdultAssigned = false;

                foreach (Visitor visitor in group.GetVisitors())
                {
                    if (!visitor.IsAdult || !firstAdultAssigned)
                    {
                        foreach (Seat seat in section.AvailableSeats)
                        {
                            if (seat.Id <= section.Columns)
                            {
                                section.OccupySeat(seat, visitor);
                                if (visitor.IsAdult)
                                {
                                    firstAdultAssigned = true;
                                }
                                break;
                            }
                        }
                    }
                    else if (visitor.IsAdult)
                    {
                        foreach (Seat seat in section.AvailableSeats)
                        {
                            if (seat.Id > section.Columns)
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