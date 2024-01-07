using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }
    public List<Group> Groups { get; private set; }
    public List<Visitor> visitorQueue { get; private set; }

    public void GenerateVisitorQueue(int visitorAmount, float adultChance)
    {
        visitorQueue.Clear();

        for (int i = 0; i < visitorAmount; i++)
        {
            visitorQueue.Add(new Visitor(i, Random.value < adultChance));
        }
    }

    public List<Visitor> GetVisitorQueue()
    {
        return visitorQueue;
    }

    public void RemoveFromQueue(Visitor visitor)
    {
        visitorQueue.Remove(visitor);
    }
}