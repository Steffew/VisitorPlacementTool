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

    public void AddVisitor(Visitor visitor)
    {
        ((List<Visitor>)Visitors).Add(visitor);
    }

    public void AddVisitors(List<Visitor> visitors)
    {
        ((List<Visitor>)Visitors).AddRange(visitors);
    }

    public void RemoveVisitor(Visitor visitor)
    {
        ((List<Visitor>)Visitors).Remove(visitor);
    }

    public void Clear()
    {
        ((List<Visitor>)Visitors).Clear();
    }
}