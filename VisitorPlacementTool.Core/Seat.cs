namespace VisitorPlacementTool.Core
{
    public class Seat
    {
        public int Id { get; private set; }
        public Visitor Occupant { get; private set; }
        public int RowNumber { get; private set; }
        public int ColumnNumber { get; private set; }

        public Seat(int id, int rowNumber, int columnNumber)
        {
            Id = id;
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        public void SetOccupant(Visitor occupant)
        {
            Occupant = occupant;
        }
    }
}