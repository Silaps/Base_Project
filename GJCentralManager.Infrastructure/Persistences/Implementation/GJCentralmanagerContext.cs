using GJCentralManager.Domain.Entities;
using GJCentralManager.Infrastructure.Models;
using GJCentralManager.Infrastructure.Persistences.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GJCentralManager.Infrastructure.Persistences.Implementation;

public partial class GJCentralmanagerContext : IdentityDbContext<ApplicationUser>, IBDBaseContext
{
    public virtual DbSet<Tenant> Tenants { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
