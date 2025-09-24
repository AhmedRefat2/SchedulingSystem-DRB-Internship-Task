using InternshipTask.Data;
using InternshipTask.Models;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Specifications;
using Talabat.Repository.GenericRepository;

namespace InternshipTask.Repository
{
    public class GenericRepository<T> : IGenericRepositoy<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<T?> GetWithSpecAsync(ISpecifications<T> specs)
         => await ApplySepcifications(specs).AsNoTracking().FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> specs)
            => await ApplySepcifications(specs).AsNoTracking().ToListAsync();

        private IQueryable<T> ApplySepcifications(ISpecifications<T> specs)
            => SpecificationsEvaluator<T>.GetQuery(_dbSet, specs);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);
    }
}
