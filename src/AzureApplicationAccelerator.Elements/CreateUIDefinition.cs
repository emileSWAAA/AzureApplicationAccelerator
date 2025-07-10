using AzureApplicationAccelerator.Elements.Converters;
using System.Text.Json.Serialization;

namespace AzureApplicationAccelerator.Elements
{
    public class CreateUIDefinition
    {
        [JsonPropertyName("$schema")]
        public string Schema { get; set; } = AzureResourceUIConstants.CreateUiDefinition.Schema;
        public string Handler { get; set; } = AzureResourceUIConstants.CreateUiDefinition.Handler;
        public string Version { get; set; } = AzureResourceUIConstants.CreateUiDefinition.Version;
        public Parameters Parameters { get; set; } = new();
    }

    public class Parameters
    {
        [JsonConverter(typeof(BasicsStepConverter))]
        public Step Basics { get; set; } = new()
        {
            Id = AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsId,
            Name = AzureResourceUIConstants.CreateUiDefinition.Steps.BasicsName
        };

        public IList<Step> Steps { get; set; } = new List<Step>();
        // TODO: Add support for the following properties:
        //public Dictionary<string, string> Outputs => throw new NotImplementedException();
        //public List<string> ResourceTypes => throw new NotImplementedException();
    }

    public class Step
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Label { get; set; }
        public Sublabel SubLabel { get; set; }
        public string BladeTitle { get; set; }


        public IList<UIElement> Elements { get; set; } = new List<UIElement>();
    }

    public class Sublabel
    {
        public string PreValidation { get; set; }
        public string PostValidation { get; set; }
    }
}
