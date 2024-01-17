using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace VisitorPlacementTool.Core
{
    public class Layout
    {
        public IEnumerable<Section> Sections { get; private set; }

        public Layout()
        {
            Sections = new List<Section>();
        }

        public void AddSection(int rows, int columns)
        {
            ((List<Section>)Sections).Add(new Section(Sections.Count() + 1, rows, columns));
        }

        public void AddSection(Section section)
        {
            ((List<Section>)Sections).Add(section);
        }

        public void RemoveSection(Section section)
        {
            ((List<Section>)Sections).Remove(section);
        }

        public void ClearSections()
        {
            ((List<Section>)Sections).Clear();
        }

        public void AssignToSections(Group group)
        {
            bool firstRowAssignment = group.GetChildrenCount() > 0 ? true : false;

            foreach (Section section in Sections)
            {
                if (section.CanGroupFit(group, firstRowAssignment))
                {
                    foreach (Visitor visitor in group.Visitors.Where(visitor => visitor.IsAssigned == false))
                    {
                        Seat seat = section.Seats.FirstOrDefault(s => s.Occupant == null);

                        section.OccupySeat(seat, visitor);
                    }
                }
            }
        }

        public int GetOccupiedSeatsAmount()
        {
            int occupiedSeats = 0;

            foreach (Section section in Sections)
            {
                occupiedSeats += section.GetOccupiedSeatsAmount();
            }

            return occupiedSeats;
        }
    }
}