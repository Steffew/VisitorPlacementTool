using NUnit.Framework;
using UnityEngine;

public class VisitorTests
{
    private VisitorManager visitorManager;
    private GameObject visitorPrefabMock;
    private Transform visitorSpawnMock;

    [SetUp]
    public void SetUp()
    {
        visitorManager = new GameObject().AddComponent<VisitorManager>();

        visitorPrefabMock = new GameObject("VisitorPrefabMock");
        visitorPrefabMock.AddComponent<Visitor>();
        visitorSpawnMock = new GameObject("VisitorSpawnMock").transform;

        visitorManager.SetVisitorPrefab(visitorPrefabMock);
        visitorManager.SetVisitorSpawn(visitorSpawnMock);

        visitorManager.Initialize();
    }

    [Test]
    public void GenerateGroup()
    {
        // Arrange
        visitorManager.SetParameters(3);

        // Act
        Group group = visitorManager.GenerateGroup();

        // Assert
        Assert.AreEqual(3, group.GetVisitors().Count, "Group should contain the correct number of visitors.");
    }

    [Test]
    public void QueueIsEmptyInitially()
    {
        Assert.IsEmpty(visitorManager.GetQueue(), "Queue should be empty initially.");
    }

    [Test]
    public void AddsGroupToQueue()
    {
        Group testGroup = new Group(1);
        visitorManager.AddToQueue(testGroup);
        Assert.Contains(testGroup, visitorManager.GetQueue(), "Queue should contain the added group.");
    }

    [Test]
    public void RemoveGroupFromQueue()
    {
        Group testGroup = new Group(1);
        visitorManager.AddToQueue(testGroup);
        visitorManager.RemoveFromQueue(testGroup);
        Assert.IsFalse(visitorManager.GetQueue().Contains(testGroup), "Group should be removed from queue.");
    }

    [Test]
    public void QueueHasCorrectCountAfterMultipleAdds()
    {
        for (int i = 0; i < 3; i++)
        {
            visitorManager.AddToQueue(new Group(i));
        }
        Assert.AreEqual(3, visitorManager.GetQueue().Count, "Queue should have 3 groups after adding 3 groups.");
    }

    [Test]
    public void QueueIsEmptyAfterRemovingAllGroups()
    {
        for (int i = 0; i < 3; i++)
        {
            visitorManager.AddToQueue(new Group(i));
        }
        foreach (var group in visitorManager.GetQueue().ToArray())
        {
            visitorManager.RemoveFromQueue(group);
        }
        Assert.IsEmpty(visitorManager.GetQueue(), "Queue should be empty after removing all groups.");
    }
}