using AzureApplicationAccelerator.Elements;
using AzureApplicationAccelerator.Shared.Interfaces;
using AzureApplicationAccelerator.Shared.Services;
using AutoFixture;
using Moq;

namespace AzureApplicationAccelerator.Shared.Tests.Services
{
    public class StepServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IDefinitionStorageService> _mockStorage;
        private readonly CreateUIDefinition _definition;
        private readonly StepService _service;
        private readonly Step _basicsStep;
        private readonly Step _customStep;

        public StepServiceTests()
        {
            _fixture = new Fixture();
            _basicsStep = _fixture.Build<Step>()
                .With(s => s.Name, AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName)
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            _customStep = _fixture.Build<Step>()
                .With(s => s.Name, "CustomStep")
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            _definition = new CreateUIDefinition
            {
                Parameters = new Parameters
                {
                    Basics = _basicsStep,
                    Steps = new List<Step> { _customStep }
                }
            };
            _mockStorage = new Mock<IDefinitionStorageService>();
            _mockStorage.SetupGet(s => s.Definition).Returns(_definition);
            _mockStorage.Setup(s => s.PersistAsync()).Returns(Task.CompletedTask);
            _service = new StepService(_mockStorage.Object);
        }

        [Fact]
        public void Constructor_SetsActiveStepToBasics()
        {
            // Arrange done in constructor
            // Act
            var activeStep = _service.ActiveStep;
            // Assert
            Assert.Equal(_basicsStep, activeStep);
        }

        [Fact]
        public void GetStep_ReturnsNull_WhenNameIsNullOrWhitespace()
        {
            // Arrange
            // Act
            var result1 = _service.GetStep(null);
            var result2 = _service.GetStep(" ");
            // Assert
            Assert.Null(result1);
            Assert.Null(result2);
        }

        [Fact]
        public void GetStep_ReturnsBasics_WhenNameIsBasics()
        {
            // Arrange
            // Act
            var step = _service.GetStep(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName);
            // Assert
            Assert.Equal(_basicsStep, step);
        }

        [Fact]
        public void GetStep_ReturnsCustomStep_WhenExists()
        {
            // Arrange
            // Act
            var step = _service.GetStep("CustomStep");
            // Assert
            Assert.Equal(_customStep, step);
        }

        [Fact]
        public void GetStep_ReturnsNull_WhenStepDoesNotExist()
        {
            // Arrange
            // Act
            var step = _service.GetStep("NonExistent");
            // Assert
            Assert.Null(step);
        }

        [Fact]
        public async Task AddStepAsync_AddsStep_WhenValidAndNotExists()
        {
            // Arrange
            var newStep = _fixture.Build<Step>()
                .With(s => s.Name, "NewStep")
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            bool eventFired = false;
            _service.OnChange += () => eventFired = true;
            // Act
            await _service.AddStepAsync(newStep);
            // Assert
            Assert.Contains(newStep, _definition.Parameters.Steps);
            Assert.True(eventFired);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task AddStepAsync_DoesNothing_WhenStepIsNullOrNameIsNullOrExists()
        {
            // Arrange
            int count = _definition.Parameters.Steps.Count;
            var stepWithNullName = _fixture.Build<Step>().With(s => s.Name, (string)null).Create();
            var duplicateStep = _fixture.Build<Step>().With(s => s.Name, "CustomStep").Create();
            // Act
            await _service.AddStepAsync(null);
            await _service.AddStepAsync(stepWithNullName);
            await _service.AddStepAsync(duplicateStep);
            // Assert
            Assert.Equal(count, _definition.Parameters.Steps.Count);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Never);
        }

        [Fact]
        public async Task EditStepAsync_UpdatesStep_WhenValid()
        {
            // Arrange
            var updated = _fixture.Build<Step>()
                .With(s => s.Name, "CustomStep")
                .With(s => s.Label, "Updated")
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            bool eventFired = false;
            _service.OnChange += () => eventFired = true;
            // Act
            var result = await _service.EditStepAsync("CustomStep", updated);
            // Assert
            Assert.Equal("Updated", result.Label);
            Assert.True(eventFired);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task EditStepAsync_Throws_WhenStepIsNullOrBasics()
        {
            // Arrange
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>((() => _service.EditStepAsync("CustomStep", null)));
            await Assert.ThrowsAsync<ArgumentNullException>((() => _service.EditStepAsync(null, _customStep)));
            await Assert.ThrowsAsync<InvalidOperationException>((() => _service.EditStepAsync(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName, _customStep)));
            await Assert.ThrowsAsync<InvalidOperationException>((() => _service.EditStepAsync("CustomStep", _basicsStep)));
        }

        [Fact]
        public async Task EditStepAsync_Throws_WhenStepDoesNotExist()
        {
            // Arrange
            var updated = _fixture.Build<Step>()
                .With(s => s.Name, "DoesNotExist")
                .With(s => s.Label, "Label")
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>((() => _service.EditStepAsync("DoesNotExist", updated)));
        }

        [Fact]
        public async Task RemoveStepAsync_RemovesStep_WhenValid()
        {
            // Arrange
            bool eventFired = false;
            _service.OnChange += () => eventFired = true;
            // Act
            await _service.RemoveStepAsync("CustomStep");
            // Assert
            Assert.DoesNotContain(_customStep, _definition.Parameters.Steps);
            Assert.True(eventFired);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task RemoveStepAsync_DoesNothing_WhenStepIsNullOrBasicsOrNotFound()
        {
            // Arrange
            int count = _definition.Parameters.Steps.Count;
            // Act
            await _service.RemoveStepAsync(null);
            await _service.RemoveStepAsync("");
            await _service.RemoveStepAsync(AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName);
            await _service.RemoveStepAsync("DoesNotExist");
            // Assert
            Assert.Equal(count, _definition.Parameters.Steps.Count);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Never);
        }

        [Fact]
        public async Task SetActiveStepAsync_SetsActiveStepAndPersists_WhenValid()
        {
            // Arrange
            var newStep = _fixture.Build<Step>()
                .With(s => s.Name, "NewStep")
                .With(s => s.Elements, new List<UIElement>())
                .Create();
            _definition.Parameters.Steps.Add(newStep);
            bool eventFired = false;
            _service.OnChange += () => eventFired = true;
            // Act
            await _service.SetActiveStepAsync(newStep);
            // Assert
            Assert.Equal(newStep, _service.ActiveStep);
            Assert.True(eventFired);
            _mockStorage.Verify(s => s.PersistAsync(), Times.Once);
        }

        [Fact]
        public async Task SetActiveStepAsync_DoesNothing_WhenStepIsNull()
        {
            // Arrange
            // Act
            await _service.SetActiveStepAsync(null);
            // Assert
            _mockStorage.Verify(s => s.PersistAsync(), Times.Never);
        }

        [Fact]
        public void SetActiveStep_SetsActiveStepToBasics_WhenBasicsName()
        {
            // Arrange
            var step = _fixture.Build<Step>()
                .With(s => s.Name, AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName)
                .Create();
            // Act
            _service.SetActiveStep(step);
            // Assert
            Assert.Equal(_basicsStep, _service.ActiveStep);
        }

        [Fact]
        public void SetActiveStep_SetsActiveStepToCustom_WhenExists()
        {
            // Arrange
            // Act
            _service.SetActiveStep(_customStep);
            // Assert
            Assert.Equal(_customStep, _service.ActiveStep);
        }

        [Fact]
        public void SetActiveStep_DoesNothing_WhenStepNotInList()
        {
            // Arrange
            var notInList = _fixture.Build<Step>()
                .With(s => s.Name, "NotInList")
                .Create();
            var before = _service.ActiveStep;
            // Act
            _service.SetActiveStep(notInList);
            // Assert
            Assert.Equal(before, _service.ActiveStep);
        }
    }
}
