namespace BaseProject.Domain.Options;

public class ConnectionStringsOptions
{
    public const string SectionName = "ConnectionStrings";
    public string? MSSQL { get; set; }
}
