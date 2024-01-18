using System.Collections.Generic;
using System.Linq;

namespace VisitorPlacementTool.Core
{
    public class Section
    {
        public int Id { get; private set; }
        public List<Seat> Seats { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Section(int id, int rows, int columns)
        {
            Id = id;
            Seats = new List<Seat>();
            Rows = rows;
            Columns = columns;

            for (int column = 1; column <= columns; column++)
            {
                for (int row = 1; row <= rows; row++)
                {
                    Seat seat = new Seat(Seats.Count, row, column);
                    Seats.Add(seat);
                }
            }
        }

        public void OccupySeat(Seat seat, Visitor visitor)
        {
            seat.SetOccupant(visitor);
            visitor.SetIsAssigned(true);
        }

        public bool CanGroupFit(Group group)
        {
            int amountOfAdultsNecessary = 1;
            int childrenCount = group.GetChildrenCount();
            bool firstRowAssignment = childrenCount > 0 ? true : false;
            int requiredSeats = childrenCount + amountOfAdultsNecessary;

            if (!firstRowAssignment)
            {
                int availableSeats = Seats.Count(seat => seat.Occupant == null);
                return requiredSeats <= availableSeats;
            }
            else
            {
                int availableSeatsInFirstRow = Seats
                    .Count(seat => seat.Occupant == null && seat.ColumnNumber == 1);

                return requiredSeats <= availableSeatsInFirstRow;
            }
        }

        public int GetOccupiedSeatsAmount()
        {
            return Seats.Count(seat => seat.Occupant != null);
        }
    }
}