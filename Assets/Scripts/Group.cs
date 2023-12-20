using System.Collections.Generic;

public class Group
{
    public int Id { get; private set; }
    public IEnumerable<Visitor> Visitors { get; private set; }

    public Group(int id)
    {
        Id = id;
        Visitors = new List<Visitor>();
    }

    public void Add(Visitor visitor)
    {
        ((List<Visitor>)Visitors).Add(visitor);
    }
}