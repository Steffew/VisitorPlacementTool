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
}