using System.Collections.Generic;
using UnityEngine;

public class AssignManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;
    [SerializeField] private VisitorManager visitorManager;

    public void AssignVisitors() // TODO: Refactor or delete this method, as there should be a first come first serve system.
    {
        List<Section> sections = layoutManager.GetSections();

        foreach (Visitor visitor in visitorManager.GetQueue())
        {
            foreach (Section section in sections)
            {
                int firstRow = section.Seats.Count / section.Rows;

                foreach (Seat seat in section.Seats)
                {
                    if (seat.Occupant == null)
                    {
                        if (seat.Id <= firstRow && !visitor.IsAdult)
                        {
                            seat.SetOccupant(visitor);
                            visitor.MoveTo(seat);
                        }
                        else if (seat.Id > firstRow && visitor.IsAdult)
                        {
                            seat.SetOccupant(visitor);
                            visitor.MoveTo(seat);
                        }
                    }
                }
            }
        }
    }
}