using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public List<Group> groups { get; private set; }

    public void CreateGroup()
    {
        groups.Add(new Group(groups.Count));
    }
}