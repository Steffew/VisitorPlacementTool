using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool.Core.Managers
{
    public class LayoutManager
    {
        public List<Section> Sections { get; private set; }
        public List<Group> Groups { get; private set; }

        public LayoutManager()
        {
            Sections = new List<Section>();
            Groups = new List<Group>();
        }

        public bool CanGroupFit(Group group, Section section, bool firstRowAssignment = false)
        {
            int amountOfAdultsNecessary = 1;
            int childrenCount = group.GetChildrenCount();
            int requiredSeats = childrenCount + amountOfAdultsNecessary;

            if (!firstRowAssignment)
            {
                int availableSeats = section.Seats.Count(seat => seat.Occupant == null);
                return requiredSeats <= availableSeats;
            }
            else
            {
                int availableSeatsInFirstRow = section.Seats
                    .Count(seat => seat.Occupant == null && seat.RowNumber == 1);

                return requiredSeats <= availableSeatsInFirstRow;
            }
        }
    }
}