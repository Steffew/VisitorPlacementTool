using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AssignManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;

    public void Assign(Visitor visitor)
    {
        List<Section> sections = layoutManager.GetSections();

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
                        break;
                    }
                    else if (seat.Id > firstRow && visitor.IsAdult)
                    {
                        seat.SetOccupant(visitor);
                        visitor.MoveTo(seat);
                        break;
                    }
                }
            }
        }
    }
}