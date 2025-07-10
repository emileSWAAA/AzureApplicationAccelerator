namespace AzureApplicationAccelerator.Elements
{
    public interface IUIElement
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Visible { get; set; }
        public string? Label { get; set; }
        public string? ToolTip { get; set; }
    }
}
