namespace AzureApplicationAccelerator.Elements.Entities.Common
{
    public class SliderElement : UIElement
    {
        public int Min { get; set; } = 0;

        public int Max { get; set; } = 100;

        public string? SubLabel { get; set; }

        public int? DefaultValue { get; set; }

        public bool? ShowStepMarkers { get; set; }

        public SliderConstraints? Constraints { get; set; } = new SliderConstraints();
    }

    public class SliderConstraints
    {
        public bool? Required { get; set; }
    }
}
