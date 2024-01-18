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
            layout.AddSection(new Section(id: 1, rows: 3, columns: 3));
            layout.AddSection(new Section(id: 2, rows: 4, columns: 2));

            var group = new Group(id: 1);
            group.AddVisitor(new Visitor(id: 1, isAdult: true));
            group.AddVisitor(new Visitor(id: 2, isAdult: true));
            group.AddVisitor(new Visitor(id: 3, isAdult: true));
            group.AddVisitor(new Visitor(id: 4, isAdult: true));

            // Act
            layout.AssignToSections(group);

            // Assert
            Assert.Equal(4, layout.GetOccupiedSeatsAmount());
        }

        [Fact]
        public void TryToFitGroupInSectionWithInsufficientSpace()
        {
            // Arrange  
            var layout = new Layout();
            Section section = new Section(id: 1, rows: 2, columns: 3);
            layout.AddSection(section);

            var group = new Group(id: 1);
            group.AddVisitor(new Visitor(id: 1, isAdult: true));
            group.AddVisitor(new Visitor(id: 2, isAdult: false));
            group.AddVisitor(new Visitor(id: 3, isAdult: false));

            // Act
            section.CanGroupFit(group);

            // Assert
            Assert.False(section.CanGroupFit(group));
        }

        [Fact]
        public void TryToFitGroupInSectionWithSufficientSpace()
        {
            // Arrange  
            var layout = new Layout();
            Section section = new Section(id: 1, rows: 2, columns: 3);
            layout.AddSection(section);

            var group = new Group(id: 1);
            group.AddVisitor(new Visitor(id: 1, isAdult: true));
            group.AddVisitor(new Visitor(id: 2, isAdult: false));

            // Act
            section.CanGroupFit(group);

            // Assert
            Assert.True(section.CanGroupFit(group));
        }
    }
}