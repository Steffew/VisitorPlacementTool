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
            int firstRow = section.Seats.Count / section.Rows;

            if (CanGroupFit(group, section) || (group.GetChildrenCount() == 0 && section.AvailableSeats.Count >= group.GetVisitors().Count))
            {
                foreach (Seat seat in section.Seats)
                {
                }
            }
        }
    }

    public bool CanGroupFit(Group group, Section section)
    {
        int seatsPerRow = section.Columns;
        int groupSize = group.GetVisitors().Count;

        foreach (Seat availableSeat in section.AvailableSeats)
        {
            int firstAvailableIndex = section.AvailableSeats.IndexOf(availableSeat);

            if (firstAvailableIndex + groupSize <= section.AvailableSeats.Count)
            {
                int rowStartIndex = availableSeat.Id / seatsPerRow * seatsPerRow;
                int rowEndIndex = rowStartIndex + seatsPerRow;

                if (availableSeat.Id + groupSize <= rowEndIndex)
                {
                    return true;
                }
            }
        }
        return false;
    }
}