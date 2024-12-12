using Application.UnitOfWork;
using Application.UnitOfWork.Repositories;
using Domain;
using Persistence.Repository.Repositories;

namespace Persistence;

public class UnitOfWork(EfContext context) : IUnitOfWork
{
    private bool _disposed;

    private IStockRepository? _stocksRepository;
    private IIndiceRepository? _indicesRepository;

    public IStockRepository StocksRepository => _stocksRepository ??=
        _stocksRepository = new StockRepository(context.Set<Stock>());

    public IIndiceRepository IndicesRepository => _indicesRepository ??=
        _indicesRepository = new IndiceRepository(context.Set<Indice>());

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                context.Dispose();
        _disposed = true;
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DropAndRoll()
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }
    
}