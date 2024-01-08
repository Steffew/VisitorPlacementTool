using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }
    public List<Group> Groups { get; private set; }
    public List<Group> Queue { get; private set; }

    private int groupSize = 3;
    private float childChanceMin = 0.2f;
    private float childChanceMax = 0.4f;

    public Group GenerateGroup(int adultChance)
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

    public void SetParameters(int groupSize)
    {
        this.groupSize = groupSize;
    }
    
    public void SetParameters(float childChanceMin, float childChanceMax)
    {
        this.childChanceMin = childChanceMin;
        this.childChanceMax = childChanceMax;
    }

    public void SetParameters(int groupSize, float childChanceMin, float childChanceMax)
    {
        this.groupSize = groupSize;
        this.childChanceMin = childChanceMin;
        this.childChanceMax = childChanceMax;
    }
}