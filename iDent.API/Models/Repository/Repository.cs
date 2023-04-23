using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Local;
using iDent.ModelLibrary.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iDent.API.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async virtual Task<Result<T>> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return new Result<T>(entity);
        }

        public async Task<Result<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(async entity =>
            {
                await _dbSet.AddAsync(entity);
            });

            return new Result<IEnumerable<T>>(entities);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return new Result<bool>(false);

            _dbSet.Remove(entity);
            return new Result<bool>(true);
        }

        public async Task<Result<T>> FindAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return new Result<T>(entity);
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return new Result<IEnumerable<T>>(entities);
        }

        public async Task<Result<Pageable<T>>> GetAllPagedAsync(Pagination pagination)
        {
            var entities = await _dbSet.ToListAsync();

            return new Result<Pageable<T>>(new Pageable<T>(entities, pagination.Page, pagination.Size));
        }

        public async Task<Result<T>> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _dbSet.Where(filter).FirstOrDefaultAsync();

            return new Result<T>(entity);
        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return new Result<T>(entity);
        }
    }
}