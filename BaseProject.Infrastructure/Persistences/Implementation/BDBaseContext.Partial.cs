using BaseProject.Domain.Attributes;
using BaseProject.Domain.Options;
using BaseProject.Infrastructure.Persistences.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BaseProject.Infrastructure.Persistences.Implementation;

[Implementation(typeof(IBDBaseContext), ServiceLifetime.Transient)]
public partial class BDBaseContext : DbContext, IBDBaseContext
{
    public ConnectionStringsOptions conectionStringValues;

    public BDBaseContext(DbContextOptions<BDBaseContext> options, IOptions<ConnectionStringsOptions> connOptions) : base(options)
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