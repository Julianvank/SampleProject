
using Application.UnitOfWork.Repositories;

namespace Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IStockRepository StocksRepository { get; }
    IIndiceRepository IndicesRepository { get; }
    
    Task SaveChangesAsync();

    Task DropAndRoll();

}