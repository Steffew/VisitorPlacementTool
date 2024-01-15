namespace VisitorPlacementTool.Core
{
    public class Visitor
    {
        public int Id { get; private set; }
        public bool IsAdult { get; private set; }

        public Visitor(int id, bool isAdult)

        {
            Id = id;
            IsAdult = isAdult;
        }
    }
}