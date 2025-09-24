using InternshipTask.Models;
using System.Linq.Expressions;

namespace Talabat.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        // Signuture For Props For Specs
        // 1. Where
        public Expression<Func<T, bool>>? Criteria { get; set; }
        // 2. Includes 
        public List<Expression<Func<T, object>>> Includes { get; set; }

        // 5. Skip 
        public int Skip { get; set; }
        // 6. Take
        public int Take { get; set; }

        // 7. Is Pagination Enabled
        public bool IsPaginationEnabled { get; set; }
    }
}
