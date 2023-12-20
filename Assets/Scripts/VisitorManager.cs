using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }

    public void CreateVisitor(bool isAdult)
    {
        Visitors.Add(new Visitor(Visitors.Count, isAdult));
    }
}