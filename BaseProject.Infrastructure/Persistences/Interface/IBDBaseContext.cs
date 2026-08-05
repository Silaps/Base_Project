using BaseProject.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Persistences.Interface;

public interface IBDBaseContext
{
    Task<int> CommitAsync(bool configureAwait = false);
    Task DisposableContextAsync();
    DbSet<ElementType> ElementTypes { get; }
    DbSet<Element> Elements { get; }
    DbSet<Form> Forms { get; }
}
