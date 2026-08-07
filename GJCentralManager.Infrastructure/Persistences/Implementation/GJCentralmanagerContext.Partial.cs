using GJCentralManager.Domain.Attributes;
using GJCentralManager.Domain.Entities;
using GJCentralManager.Domain.Options;
using GJCentralManager.Infrastructure.Persistences.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GJCentralManager.Infrastructure.Persistences.Implementation;

[Implementation(typeof(IBDBaseContext), ServiceLifetime.Transient)]
public partial class GJCentralmanagerContext : IdentityDbContext<ApplicationUser>, IBDBaseContext
{
    public ConnectionStringsOptions conectionStringValues;

    public GJCentralmanagerContext(DbContextOptions<GJCentralmanagerContext> options, IOptions<ConnectionStringsOptions> connOptions) : base(options)
    {
        conectionStringValues = connOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured && conectionStringValues?.MSSQL is not null)
        {
            optionsBuilder.UseSqlServer(conectionStringValues.MSSQL);
        }
    }

    public async Task<int> CommitAsync(bool configureAwait = false)
    {
        return await SaveChangesAsync().ConfigureAwait(configureAwait);
    }

    public async Task DisposableContextAsync()
    {
        await DisposeAsync().ConfigureAwait(false);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {

    }
}