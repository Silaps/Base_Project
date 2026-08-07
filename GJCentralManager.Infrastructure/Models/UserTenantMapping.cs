namespace GJCentralManager.Infrastructure.Models;

public class UserTenantMapping
{
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    // Metadata Específica por Tenant
    public string RoleInTenant { get; set; } = "Member";
    public string PermissionsJson { get; set; } = "[]";
    public bool IsActive { get; set; } = true;
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
