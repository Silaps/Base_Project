using System.Text.Json;

namespace BaseProject.Domain.Dtos;

public class FormDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public JsonDocument? Fields { get; set; }
}
