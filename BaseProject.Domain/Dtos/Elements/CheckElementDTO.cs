namespace BaseProject.Domain.Dtos.Elements;

public class CheckElementDTO : IUIElement
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Required { get; set; }
    public bool Checked { get; set; }
}
