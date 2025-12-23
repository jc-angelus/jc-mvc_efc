using System.Linq.Expressions;

namespace TestApp.Infrastructure.Repositories.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {        
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        T? ReadByConditionAsync(Expression<Func<T, bool>> whereCondition = null);
        Task<bool> UpdateAsync(T entity, object key);
        Task<bool> DeleteAsync(object key);
        Task<IEnumerable<T>> ListAsync();
    }
}
