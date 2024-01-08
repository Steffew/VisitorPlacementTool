using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }
    public List<Group> Groups { get; private set; }
    public List<Group> Queue { get; private set; }

    public Group GenerateGroup(int groupSize, int adultChance)
    {
        Group newGroup = new Group(Groups.Count);
        List<Visitor> visitors = new List<Visitor>();

        visitors.Add(new Visitor(0, true));

        for (int i = 1; i < groupSize; i++)
        {
            visitors.Add(new Visitor(i + 1, Random.value < adultChance));
        }

        newGroup.AddVisitors(visitors);

        return newGroup;
    }

    public void AddToQueue(Group group)
    {
        Queue.Add(group);
    }

    public void RemoveFromQueue(Group group)
    {
        Queue.Remove(group);
    }

    public List<Group> GetQueue()
    {
        return Queue;
    }
}