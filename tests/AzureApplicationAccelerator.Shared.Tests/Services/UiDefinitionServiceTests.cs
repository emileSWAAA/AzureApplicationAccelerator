using AutoFixture;
using AutoFixture.AutoMoq;
using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Models;
using AzureApplicationAccelerator.Shared.Services;
using Microsoft.JSInterop;
using Moq;

namespace AzureApplicationAccelerator.Shared.Tests.Services
{
    public class UiDefinitionServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IJSRuntime> _mockJsRuntime;
        private readonly Mock<IDefinitionStorageService> _mockStorage;
        private readonly Mock<IStepService> _mockStepService;
        private readonly Mock<IElementService> _mockElementService;
        private readonly UIDefinitionService _sut;

        public UiDefinitionServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            
            // Configure AutoFixture to create valid objects
            _fixture.Register(() => new UIElement
            {
                Name = _fixture.Create<string>(),
                Type = _fixture.Create<string>()
            });

            _mockJsRuntime = new Mock<IJSRuntime>();
            _mockStorage = new Mock<IDefinitionStorageService>();
            _mockStepService = new Mock<IStepService>();
            _mockElementService = new Mock<IElementService>();

            _sut = new UIDefinitionService(
                _mockJsRuntime.Object,
                _mockStorage.Object,
                _mockStepService.Object,
                _mockElementService.Object);
        }

        [Fact]
        public void Constructor_SubscribesToServiceEvents()
        {
            // Arrange
            var mockStorage = new Mock<IDefinitionStorageService>();
            var mockStepService = new Mock<IStepService>();
            var mockElementService = new Mock<IElementService>();

            // Act
            var service = new UIDefinitionService(
                _mockJsRuntime.Object,
                mockStorage.Object,
                mockStepService.Object,
                mockElementService.Object);
            
            // Assert - Trigger events to verify subscription
            var storageChangeTriggered = false;
            var stepChangeTriggered = false;
            var elementChangeTriggered = false;

            service.OnChange += () => storageChangeTriggered = true;
            service.OnChange += () => stepChangeTriggered = true;
            service.OnChange += () => elementChangeTriggered = true;

            mockStorage.Raise(s => s.OnChange += null);
            Assert.True(storageChangeTriggered);

            mockStepService.Raise(s => s.OnChange += null);
            Assert.True(stepChangeTriggered);

            mockElementService.Raise(s => s.OnChange += null);
            Assert.True(elementChangeTriggered);
        }

        [Fact]
        public void Definition_ReturnsStorageDefinition()
        {
            // Arrange
            var expectedDefinition = _fixture.Create<CreateUIDefinition>();
            _mockStorage.Setup(s => s.Definition).Returns(expectedDefinition);

            // Act
            var result = _sut.Definition;

            // Assert
            Assert.Equal(expectedDefinition, result);
            _mockStorage.Verify(s => s.Definition, Times.Once);
        }

        [Fact]
        public void ActiveStep_ReturnsStepServiceActiveStep()
        {
            // Arrange
            var expectedStep = _fixture.Create<Step>();
            _mockStepService.Setup(s => s.ActiveStep).Returns(expectedStep);

            // Act
            var result = _sut.ActiveStep;

            // Assert
            Assert.Equal(expectedStep, result);
            _mockStepService.Verify(s => s.ActiveStep, Times.Once);
        }

        [Fact]
        public async Task InitializeAsync_CallsStorageInitializeAndSetsActiveStep()
        {
            // Arrange
            var definition = _fixture.Create<CreateUIDefinition>();
            _mockStorage.Setup(s => s.Definition).Returns(definition);

            // Act
            await _sut.InitializeAsync();

            // Assert
            _mockStorage.Verify(s => s.InitializeAsync(), Times.Once);
            _mockStepService.Verify(s => s.SetActiveStep(definition.Parameters.Basics), Times.Once);
        }

        [Fact]
        public async Task ClearAsync_CallsStorageClearAndSetsActiveStep()
        {
            // Arrange
            var definition = _fixture.Create<CreateUIDefinition>();
            _mockStorage.Setup(s => s.Definition).Returns(definition);

            // Act
            await _sut.ClearAsync();

            // Assert
            _mockStorage.Verify(s => s.ClearAsync(), Times.Once);
            _mockStepService.Verify(s => s.SetActiveStep(definition.Parameters.Basics), Times.Once);
        }

        [Fact]
        public async Task GetStep_ReturnsStepFromStepService()
        {
            // Arrange
            var stepName = _fixture.Create<string>();
            var expectedStep = _fixture.Create<Step>();
            _mockStepService.Setup(s => s.GetStep(stepName)).Returns(expectedStep);

            // Act
            var result = await _sut.GetStep(stepName);

            // Assert
            Assert.Equal(expectedStep, result);
            _mockStepService.Verify(s => s.GetStep(stepName), Times.Once);
        }

        [Fact]
        public async Task AddStepAsync_CallsStepServiceAddStepAsync()
        {
            // Arrange
            var step = _fixture.Create<Step>();

            // Act
            await _sut.AddStepAsync(step);

            // Assert
            _mockStepService.Verify(s => s.AddStepAsync(step), Times.Once);
        }

        [Fact]
        public async Task EditStepAsync_CallsStepServiceEditStepAsync()
        {
            // Arrange
            var stepName = _fixture.Create<string>();
            var updatedStep = _fixture.Create<Step>();
            var expectedResult = _fixture.Create<Step>();
            _mockStepService.Setup(s => s.EditStepAsync(stepName, updatedStep))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _sut.EditStepAsync(stepName, updatedStep);

            // Assert
            Assert.Equal(expectedResult, result);
            _mockStepService.Verify(s => s.EditStepAsync(stepName, updatedStep), Times.Once);
        }

        [Fact]
        public async Task RemoveStepAsync_CallsStepServiceRemoveStepAsync()
        {
            // Arrange
            var stepName = _fixture.Create<string>();

            // Act
            await _sut.RemoveStepAsync(stepName);

            // Assert
            _mockStepService.Verify(s => s.RemoveStepAsync(stepName), Times.Once);
        }

        [Fact]
        public async Task SetActiveStepAsync_CallsStepServiceSetActiveStepAsync()
        {
            // Arrange
            var step = _fixture.Create<Step>();

            // Act
            await _sut.SetActiveStepAsync(step);

            // Assert
            _mockStepService.Verify(s => s.SetActiveStepAsync(step), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithUIElement_CallsElementServiceAddElementAsync()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();

            // Act
            await _sut.AddElementAsync(element);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(element), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItem_CallsElementServiceAddElementAsyncWithDefaultValues()
        {
            // Arrange
            var toolbarItem = CreateTestToolbarItem();

            // Act
            await _sut.AddElementAsync(toolbarItem);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, null, "canvas"), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItemAndIndex_CallsElementServiceAddElementAsyncWithIndex()
        {
            // Arrange
            var toolbarItem = CreateTestToolbarItem();
            var index = 5;

            // Act
            await _sut.AddElementAsync(toolbarItem, index);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, index, "canvas"), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithToolbarItemIndexAndTarget_CallsElementServiceAddElementAsync()
        {
            // Arrange
            var toolbarItem = CreateTestToolbarItem();
            var index = 3;
            var target = "sidebar";

            // Act
            await _sut.AddElementAsync(toolbarItem, index, target);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, index, target), Times.Once);
        }

        [Fact]
        public async Task UpdateElementAsync_CallsElementServiceUpdateElementAsync()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();

            // Act
            await _sut.UpdateElementAsync(element);

            // Assert
            _mockElementService.Verify(s => s.UpdateElementAsync(element), Times.Once);
        }

        [Fact]
        public async Task RemoveElementAsync_CallsElementServiceRemoveElementAsync()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();

            // Act
            await _sut.RemoveElementAsync(element);

            // Assert
            _mockElementService.Verify(s => s.RemoveElementAsync(element), Times.Once);
        }

        [Fact]
        public async Task InsertAtAsync_CallsElementServiceInsertAtAsync()
        {
            // Arrange
            var element = _fixture.Create<UIElement>();
            var targetIndex = 10;

            // Act
            await _sut.InsertAtAsync(element, targetIndex);

            // Assert
            _mockElementService.Verify(s => s.InsertAtAsync(element, targetIndex), Times.Once);
        }

        [Fact]
        public void OnChange_IsTriggeredWhenStorageChanges()
        {
            // Arrange
            var onChangeTriggered = false;
            _sut.OnChange += () => onChangeTriggered = true;

            // Act - Trigger the storage OnChange event
            _mockStorage.Raise(s => s.OnChange += null);

            // Assert
            Assert.True(onChangeTriggered);
        }

        [Fact]
        public void OnChange_IsTriggeredWhenStepServiceChanges()
        {
            // Arrange
            var onChangeTriggered = false;
            _sut.OnChange += () => onChangeTriggered = true;

            // Act - Trigger the step service OnChange event
            _mockStepService.Raise(s => s.OnChange += null);

            // Assert
            Assert.True(onChangeTriggered);
        }

        [Fact]
        public void OnChange_IsTriggeredWhenElementServiceChanges()
        {
            // Arrange
            var onChangeTriggered = false;
            _sut.OnChange += () => onChangeTriggered = true;

            // Act - Trigger the element service OnChange event
            _mockElementService.Raise(s => s.OnChange += null);

            // Assert
            Assert.True(onChangeTriggered);
        }

        [Fact]
        public void OnChange_MultipleSubscribers_AllGetNotified()
        {
            // Arrange
            var subscriber1Triggered = false;
            var subscriber2Triggered = false;
            _sut.OnChange += () => subscriber1Triggered = true;
            _sut.OnChange += () => subscriber2Triggered = true;

            // Act
            _mockStorage.Raise(s => s.OnChange += null);

            // Assert
            Assert.True(subscriber1Triggered);
            Assert.True(subscriber2Triggered);
        }

        [Fact]
        public async Task GetStep_WithNullStepName_PassesNullToStepService()
        {
            // Arrange
            string? stepName = null;
            var expectedStep = _fixture.Create<Step>();
            _mockStepService.Setup(s => s.GetStep(stepName!)).Returns(expectedStep);

            // Act
            var result = await _sut.GetStep(stepName!);

            // Assert
            Assert.Equal(expectedStep, result);
            _mockStepService.Verify(s => s.GetStep(stepName!), Times.Once);
        }

        [Fact]
        public async Task AddElementAsync_WithNullToolbarItem_PassesNullToElementService()
        {
            // Arrange
            ToolbarItem? toolbarItem = null;

            // Act
            await _sut.AddElementAsync(toolbarItem);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, null, "canvas"), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(100)]
        public async Task AddElementAsync_WithVariousIndexValues_PassesCorrectValues(int index)
        {
            // Arrange
            var toolbarItem = CreateTestToolbarItem();

            // Act
            await _sut.AddElementAsync(toolbarItem, index);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, index, "canvas"), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData("canvas")]
        [InlineData("sidebar")]
        [InlineData("custom-target")]
        public async Task AddElementAsync_WithVariousTargetValues_PassesCorrectValues(string target)
        {
            // Arrange
            var toolbarItem = CreateTestToolbarItem();
            var index = 5;

            // Act
            await _sut.AddElementAsync(toolbarItem, index, target);

            // Assert
            _mockElementService.Verify(s => s.AddElementAsync(toolbarItem, index, target), Times.Once);
        }

        [Fact]
        public async Task InitializeAsync_WhenStorageDefinitionIsNull_SetsActiveStepCorrectly()
        {
            // Arrange
            var definition = new CreateUIDefinition();
            _mockStorage.Setup(s => s.Definition).Returns(definition);

            // Act
            await _sut.InitializeAsync();

            // Assert
            _mockStorage.Verify(s => s.InitializeAsync(), Times.Once);
            _mockStepService.Verify(s => s.SetActiveStep(definition.Parameters.Basics), Times.Once);
        }

        [Fact]
        public async Task ClearAsync_WhenStorageDefinitionIsNull_SetsActiveStepCorrectly()
        {
            // Arrange
            var definition = new CreateUIDefinition();
            _mockStorage.Setup(s => s.Definition).Returns(definition);

            // Act
            await _sut.ClearAsync();

            // Assert
            _mockStorage.Verify(s => s.ClearAsync(), Times.Once);
            _mockStepService.Verify(s => s.SetActiveStep(definition.Parameters.Basics), Times.Once);
        }

        [Fact]
        public async Task GetStep_ReturnsNullWhenStepServiceReturnsNull()
        {
            // Arrange
            var stepName = _fixture.Create<string>();
            _mockStepService.Setup(s => s.GetStep(stepName)).Returns((Step?)null);

            // Act
            var result = await _sut.GetStep(stepName);

            // Assert
            Assert.Null(result);
            _mockStepService.Verify(s => s.GetStep(stepName), Times.Once);
        }

        [Fact]
        public void NotifyChanged_IsCalledWhenAnyServiceChanges()
        {
            // Arrange
            var changeCount = 0;
            _sut.OnChange += () => changeCount++;

            // Act
            _mockStorage.Raise(s => s.OnChange += null);
            _mockStepService.Raise(s => s.OnChange += null);
            _mockElementService.Raise(s => s.OnChange += null);

            // Assert
            Assert.Equal(3, changeCount);
        }

        private static ToolbarItem CreateTestToolbarItem()
        {
            return new ToolbarItem
            {
                Name = "TestToolbarItem",
                Label = "Test Label",
                Icon = new Microsoft.FluentUI.AspNetCore.Components.Icons.Regular.Size20.Add(),
                Type = "Microsoft.Common.TextBox"
            };
        }
    }
}
