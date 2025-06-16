namespace AzureApplicationAccelerator.Shared.Interfaces
{
    public interface IUIElement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Visible { get; set; }
        public string? Label { get; set; }
        public string? ToolTip { get; set; }
    }
}
