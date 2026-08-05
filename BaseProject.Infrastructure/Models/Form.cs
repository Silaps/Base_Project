using System.Text.Json;

namespace BaseProject.Infrastructure.Models;

public class Form
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public JsonDocument? Fields { get; set; } = null;
}
