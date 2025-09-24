using InternshipTask.Models;
using Talabat.Core.Specifications;

namespace InternshipTask.Repository
{
    public interface IGenericRepositoy<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> specs);
        Task<T?> GetWithSpecAsync(ISpecifications<T> specs);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
