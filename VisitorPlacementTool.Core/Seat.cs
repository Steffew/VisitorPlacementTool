namespace VisitorPlacementTool.Core
{
    public class Seat
    {
        public int Id { get; private set; }
        public Visitor Occupant { get; private set; }
        public int RowNumber { get; private set; }
        public int ColumnNumber { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetOccupant(Visitor occupant)
        {
            Occupant = occupant;
        }
    }
}