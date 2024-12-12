using Application.UnitOfWork.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.Repositories;

public class StockRepository(DbSet<Stock> dbSet) : GenericRepository<Stock>(dbSet), IStockRepository
{
}