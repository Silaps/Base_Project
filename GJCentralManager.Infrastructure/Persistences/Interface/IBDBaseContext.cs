namespace GJCentralManager.Infrastructure.Persistences.Interface;

public interface IBDBaseContext
{
    Task<int> CommitAsync(bool configureAwait = false);
    Task DisposableContextAsync();
}
