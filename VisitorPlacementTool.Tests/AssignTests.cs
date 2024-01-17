using Xunit;
using VisitorPlacementTool.Core;
using System.Linq;
namespace VisitorPlacementTool.Tests
{
    public class AssignTests
    {
        [Fact]
        public void GetOccupiedSeatsAmount()
        {
            // Arrange  
            var layout = new Layout();
            layout.AddSection(new Section(id: 1, rows: 7, columns: 3));
            layout.AddSection(new Section(id: 2, rows: 7, columns: 3));

            var group = new Group(id: 1);
            group.AddVisitor(new Visitor(id: 1, isAdult: true));
            group.AddVisitor(new Visitor(id: 2, isAdult: true));
            group.AddVisitor(new Visitor(id: 3, isAdult: true));

            // Act
            layout.AssignToSections(group);

            // Assert
            Assert.Equal(6, layout.GetOccupiedSeatsAmount());
        }

        [Fact]
        public void AddAdultGroupToLayoutWithSingleSection()
        {
            // Arrange  
            var layout = new Layout();
            layout.AddSection(new Section(id: 1, rows: 7, columns: 3));

            var group = new Group(id: 1);
            group.AddVisitor(new Visitor(id: 1, isAdult: true));
            group.AddVisitor(new Visitor(id: 2, isAdult: true));
            group.AddVisitor(new Visitor(id: 3, isAdult: true));

            // Act
            layout.AssignToSections(group);

            // Assert
            Assert.Equal(3, layout.GetOccupiedSeatsAmount());
        }
    }
}