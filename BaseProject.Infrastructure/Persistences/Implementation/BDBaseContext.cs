using BaseProject.Infrastructure.Models;
using BaseProject.Infrastructure.Persistences.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BaseProject.Infrastructure.Persistences.Implementation;

public partial class BDBaseContext : DbContext, IBDBaseContext
{ 
    public virtual DbSet<ElementType> ElementTypes { get; set; } = null!;
    public virtual DbSet<Element> Elements { get; set; } = null!;
    public virtual DbSet<Form> Forms { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElementType>(c =>
        {
            c.HasIndex(x => x.Id).IsUnique();
        });

        modelBuilder.Entity<Element>(c =>
        {
            c.HasIndex(x => x.Id).IsUnique();
        });

        modelBuilder.Entity<Form>(c =>
        {
            c.HasIndex(x => x.Id).IsUnique();
            c.Property(x => x.Fields).HasColumnType("json");
            c.Property(e => e.Fields)
                .HasConversion(
                    doc => doc != null ? doc.RootElement.GetRawText() : "{}",
                    json => JsonDocument.Parse(json, new JsonDocumentOptions())
                );
        });
               
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
