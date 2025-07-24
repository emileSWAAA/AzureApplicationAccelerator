using AutoFixture;
using AutoFixture.AutoMoq;
using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Elements.Entities.Common;
using AzureApplicationAccelerator.Shared.Constants;
using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Models;
using AzureApplicationAccelerator.Shared.Services;
using Moq;

namespace AzureApplicationAccelerator.Shared.Tests.Services
{
    public class ElementServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IStepService> _mockStepService;
        private readonly Mock<IDefinitionStorageService> _mockStorageService;
        private readonly ElementService _elementService;
        private readonly Step _activeStep;

        public ElementServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _mockStepService = new Mock<IStepService>();
            _mockStorageService = new Mock<IDefinitionStorageService>();
            
            _activeStep = new Step
            {
                Name = "TestStep",
                Elements = new List<UIElement>()
            };
            
            _mockStepService.Setup(x => x.ActiveStep).Returns(_activeStep);
            
            _elementService = new ElementService(_mockStepService.Object, _mockStorageService.Object);
        }

        [Fact]
        public async Task AddElementAsync_WithUIElement_AddsElementAndPersists()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.AddElementAsync(element);

            // Assert
            Assert.Contains(element, _activeStep.Elements);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithNullUIElement_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _elementService.AddElementAsync((UIElement)null!));
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItem_AddsElementToCanvas()
        {
            // Arrange
            var toolbarItem = new Mock<ToolbarItem>();
            var expectedElement = _fixture.Create<UIElement>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns(expectedElement);
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.AddElementAsync(toolbarItem.Object, target: ToolbarConstants.CanvasId);

            // Assert
            Assert.Contains(expectedElement, _activeStep.Elements);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItemAndIndex_InsertsElementAtIndex()
        {
            // Arrange
            var existingElement = _fixture.Create<UIElement>();
            _activeStep.Elements.Add(existingElement);
            
            var toolbarItem = new Mock<ToolbarItem>();
            var newElement = _fixture.Create<UIElement>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns(newElement);

            // Act
            await _elementService.AddElementAsync(toolbarItem.Object, index: 0, target: ToolbarConstants.CanvasId);

            // Assert
            Assert.Equal(newElement, _activeStep.Elements[0]);
            Assert.Equal(existingElement, _activeStep.Elements[1]);
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItemAndSectionTarget_AddsToSection()
        {
            // Arrange
            var sectionElement = new SectionElement 
            { 
                Name = "TestSection", 
                Type = "Section",
                Elements = new List<UIElement>()
            };
            _activeStep.Elements.Add(sectionElement);

            var toolbarItem = new Mock<ToolbarItem>();
            var newElement = _fixture.Create<UIElement>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns(newElement);

            var target = $"{ToolbarConstants.SectionCanvasId}TestSection";

            // Act
            await _elementService.AddElementAsync(toolbarItem.Object, target: target);

            // Assert
            Assert.Contains(newElement, sectionElement.Elements);
        }

        [Fact]
        public async Task AddElementAsync_WithNullToolbarItem_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _elementService.AddElementAsync((ToolbarItem)null!));
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItemThatReturnsNull_ThrowsArgumentException()
        {
            // Arrange
            var toolbarItem = new Mock<ToolbarItem>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns((UIElement)null!);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _elementService.AddElementAsync(toolbarItem.Object));
        }

        [Fact]
        public async Task UpdateElementAsync_WithExistingElement_UpdatesElement()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            _activeStep.Elements.Add(element);
            
            var updatedElement = _fixture.Create<UIElement>();
            updatedElement.Name = element.Name; // Keep same reference for IndexOf
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.UpdateElementAsync(element);

            // Assert
            Assert.Contains(element, _activeStep.Elements);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateElementAsync_WithNonExistingElement_DoesNotPersist()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.UpdateElementAsync(element);

            // Assert
            Assert.False(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Never);
        }

        [Fact]
        public async Task UpdateElementAsync_WithNullElement_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _elementService.UpdateElementAsync(null!));
        }

        [Fact]
        public async Task RemoveElementAsync_WithElementInStep_RemovesElement()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            _activeStep.Elements.Add(element);
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.RemoveElementAsync(element);

            // Assert
            Assert.DoesNotContain(element, _activeStep.Elements);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task RemoveElementAsync_WithElementInSection_RemovesFromSection()
        {
            // Arrange
            var sectionElement = new SectionElement 
            { 
                Name = "TestSection", 
                Type = "Section",
                Elements = new List<UIElement>()
            };
            var elementToRemove = _fixture.Create<UIElement>();
            sectionElement.Elements.Add(elementToRemove);
            _activeStep.Elements.Add(sectionElement);
            
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.RemoveElementAsync(elementToRemove);

            // Assert
            Assert.DoesNotContain(elementToRemove, sectionElement.Elements);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task RemoveElementAsync_WithNonExistingElement_DoesNotPersist()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.RemoveElementAsync(element);

            // Assert
            Assert.False(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Never);
        }

        [Fact]
        public async Task RemoveElementAsync_WithNullElement_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _elementService.RemoveElementAsync(null!));
        }

        [Fact]
        public async Task InsertAtAsync_WithValidElement_MovesElementToTargetIndex()
        {
            // Arrange
            var element1 = _fixture.Create<UIElement>();
            var element2 = _fixture.Create<UIElement>();
            var element3 = _fixture.Create<UIElement>();
            
            _activeStep.Elements.Add(element1);
            _activeStep.Elements.Add(element2);
            _activeStep.Elements.Add(element3);
            
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act - Move element2 from index 1 to index 0
            await _elementService.InsertAtAsync(element2, 0);

            // Assert
            Assert.Equal(element2, _activeStep.Elements[0]);
            Assert.Equal(element1, _activeStep.Elements[1]);
            Assert.Equal(element3, _activeStep.Elements[2]);
            Assert.True(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task InsertAtAsync_WithSameIndex_DoesNotMoveElement()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            _activeStep.Elements.Add(element);
            var eventFired = false;
            _elementService.OnChange += () => eventFired = true;

            // Act
            await _elementService.InsertAtAsync(element, 0);

            // Assert
            Assert.Equal(element, _activeStep.Elements[0]);
            Assert.False(eventFired);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Never);
        }

        [Fact]
        public async Task InsertAtAsync_WithNonExistingElement_ThrowsInvalidOperationException()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _elementService.InsertAtAsync(element, 0));
        }

        [Fact]
        public async Task InsertAtAsync_WithNullElement_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _elementService.InsertAtAsync(null!, 0));
        }

        [Fact]
        public async Task AddElementAsync_WithInvalidTarget_DoesNotAddElement()
        {
            // Arrange
            var toolbarItem = new Mock<ToolbarItem>();
            var element = _fixture.Create<UIElement>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns(element);

            // Act
            await _elementService.AddElementAsync(toolbarItem.Object, target: "invalid-target");

            // Assert
            Assert.DoesNotContain(element, _activeStep.Elements);
            _mockStorageService.Verify(x => x.PersistAsync(), Times.Once); // Still persists even if no change
        }

        [Fact]
        public async Task AddElementAsync_WithIndexGreaterThanCount_AddsElementAtEnd()
        {
            // Arrange
            var existingElement = _fixture.Create<UIElement>();
            _activeStep.Elements.Add(existingElement);
            
            var toolbarItem = new Mock<ToolbarItem>();
            var newElement = _fixture.Create<UIElement>();
            toolbarItem.Setup(x => x.ToUiElement()).Returns(newElement);

            // Act
            await _elementService.AddElementAsync(toolbarItem.Object, index: 999, target: ToolbarConstants.CanvasId);

            // Assert
            Assert.Equal(newElement, _activeStep.Elements[1]);
            Assert.Equal(2, _activeStep.Elements.Count);
        }
    }
}