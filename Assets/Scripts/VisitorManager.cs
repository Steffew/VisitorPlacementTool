using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }
    public List<Group> Groups { get; private set; }
    public List<Visitor> Queue { get; private set; }

    public List<Visitor> GetQueue()
    {
        return Queue;
    }

    public void AddToQueue(int visitorAmount)
    {
        //Queue.Clear();

        //for (int i = 0; i < visitorAmount; i++)
        //{
        //    Queue.Add(new Visitor(i, Random.value < adultChance));
        //}
    }

    public Group GenerateGroup(int minGroupSize, int maxGroupSize, int adultChance)
    {
        Group newGroup = new Group(Groups.Count);
        List<Visitor> visitors = new List<Visitor>();

        visitors.Add(new Visitor(0, true));

        for (int i = 0; i < Random.Range(minGroupSize, maxGroupSize); i++)
        {
            visitors.Add(new Visitor(i + 1, Random.value < adultChance));
        }

        newGroup.AddVisitors(visitors);
        Groups.Add(newGroup);

        return newGroup;
    }

    public void RemoveFromQueue(Visitor visitor)
    {
        Queue.Remove(visitor);
    }
}