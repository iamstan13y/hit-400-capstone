using iDent.ModelLibrary.Models.Local;
using iDent.ModelLibrary.Utility;
using System.Linq.Expressions;

namespace iDent.API.Models.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<Result<T>> FindAsync(int id);
        Task<Result<T>> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result<Pageable<T>>> GetAllPagedAsync(Pagination pagination);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<T>> UpdateAsync(T entity);
    }
}