using Microsoft.AspNetCore.Identity;

namespace GJCentralManager.Infrastructure.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public bool IsGlobalSuperAdmin { get; set; } = false;
        
    public ICollection<UserTenantMapping> TenantMappings { get; set; } = new List<UserTenantMapping>();
}