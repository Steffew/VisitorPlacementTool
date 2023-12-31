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

    public int GetChildrenCount()
    {
        int count = 0;

        foreach (Visitor visitor in Visitors)
        {
            if (!visitor.IsAdult)
            {
                count++;
            }
        }

        return count;
    }

    public List<Visitor> GetVisitors()
    {
        return (List<Visitor>)Visitors;
    }

    public void Clear()
    {
        ((List<Visitor>)Visitors).Clear();
    }
}