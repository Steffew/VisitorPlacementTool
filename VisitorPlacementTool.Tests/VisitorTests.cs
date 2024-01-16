using Xunit;
using VisitorPlacementTool.Core;
using System.Linq;
namespace VisitorPlacementTool.Tests
{
    public class VisitorTests
    {
        [Fact]
        public void AddVisitorToGroup()
        {
            // Arrange  
            var visitor = new Visitor(1, true);
            var group = new Group(1);

            // Act
            group.AddVisitor(visitor);

            // Assert
            Assert.Contains(visitor, group.Visitors);
        }

        [Fact]
        public void RemoveVisitorFromGroup()
        {
            // Arrange  
            var visitor = new Visitor(1, true);
            var group = new Group(1);
            group.AddVisitor(visitor);

            // Act
            group.RemoveVisitor(visitor);

            // Assert
            Assert.DoesNotContain(visitor, group.Visitors);
        }

        [Fact]
        public void CreateEmptyGroup()
        {
            // Arrange  
            var group = new Group(1);

            // Act
            var result = group.GetVisitorsCount();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CreateGroupWithMultipleAdults()
        {
            // Arrange  
            var group = new Group(1);
            group.AddVisitor(new Visitor(1, true));
            group.AddVisitor(new Visitor(2, true));
            group.AddVisitor(new Visitor(3, true));

            // Act
            var result = group.GetAdultsCount();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void CreateGroupWithMultipleChildren()
        {
            // Arrange  
            var group = new Group(1);
            group.AddVisitor(new Visitor(1, false));
            group.AddVisitor(new Visitor(2, false));
            group.AddVisitor(new Visitor(3, false));

            // Act
            var result = group.GetChildrenCount();

            // Assert
            Assert.Equal(3, result);
        }
    }
}