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

            for (int row = 1; row <= rows; row++) // todo: check if this is correct
            {
                for (int column = 1; column <= columns; column++)
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

        public bool CanGroupFit(Group group, bool firstRowAssignment = false)
        {
            int amountOfAdultsNecessary = 1;
            int childrenCount = group.GetChildrenCount();
            int requiredSeats = childrenCount + amountOfAdultsNecessary;

            if (!firstRowAssignment)
            {
                int availableSeats = Seats.Count(seat => seat.Occupant == null);
                return requiredSeats <= availableSeats;
            }
            else
            {
                int availableSeatsInFirstRow = Seats
                    .Count(seat => seat.Occupant == null && seat.RowNumber == 1);

                return requiredSeats <= availableSeatsInFirstRow;
            }
        }

        public int GetOccupiedSeatsAmount()
        {
            return Seats.Count(seat => seat.Occupant != null);
        }
    }
}