namespace Application.UnitOfWork;

public interface IRepository<T> where T : class
{
   Task<T?> GetByIdAsync(object id); 
   Task<IList<T>> GetAllAsync();
   void Add(T entity);
   void AddRange(IList<T> entities);
   void Update(T entity);
   void Delete(T entity);
}