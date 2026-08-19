namespace BaseProject.Domain.Dtos.Elements;

public class RadioElementDTO : IUIElement
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Required { get; set; }
    public IEnumerable<OptionElementDTO> Options { get; set; } = [];
}
