using Application.UnitOfWork.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.Repositories;

public class IndiceRepository(DbSet<Indice> dbSet) : GenericRepository<Indice>(dbSet), IIndiceRepository
{
    
}