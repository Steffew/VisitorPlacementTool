using System.Collections.Generic;
using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    public List<Visitor> Visitors { get; private set; }
    public List<Group> Groups { get; private set; }
    public List<Group> Queue { get; private set; }

    [SerializeField] private int groupSize = 3;
    [SerializeField] private float childChanceMin = 0.2f;
    [SerializeField] private float childChanceMax = 0.4f;
    [SerializeField] private GameObject visitorPrefab;
    [SerializeField] private Transform visitorSpawn;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        Visitors = new List<Visitor>();
        Groups = new List<Group>();
        Queue = new List<Group>();
    }

    public void SetVisitorPrefab(GameObject prefab)
    {
        visitorPrefab = prefab;
    }

    public void SetVisitorSpawn(Transform spawn)
    {
        visitorSpawn = spawn;
    }

    public Group GenerateGroup()
    {
        Group newGroup = new Group(Groups.Count);
        List<Visitor> visitors = new List<Visitor>();

        GameObject firstVisitorObj = Instantiate(visitorPrefab, visitorSpawn.position, Quaternion.identity);
        Visitor firstVisitor = firstVisitorObj.GetComponent<Visitor>();
        firstVisitor.Initialize(0, true);
        visitors.Add(firstVisitor);

        for (int i = 1; i < groupSize; i++)
        {
            GameObject visitorObj = Instantiate(visitorPrefab, visitorSpawn.position, Quaternion.identity);
            Visitor visitor = visitorObj.GetComponent<Visitor>();
            float childChance = Random.Range(childChanceMin, childChanceMax);
            bool isAdult = Random.value > childChance;
            visitor.Initialize(i, isAdult);
            visitors.Add(visitor);
        }

        newGroup.AddVisitors(visitors);

        return newGroup;
    }

    public void AddToQueue(Group group)
    {
        Queue.Add(group);
    }

    public void AddToQueue()
    {
        Queue.Add(GenerateGroup());
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