using InternshipTask.Models;
using Talabat.Core.Specifications;

namespace InternshipTask.Specifications
{
    public class RoutesWithPaginationSpecs : BaseSpecifications<Models.Route>
    {
        public RoutesWithPaginationSpecs(int pageIndex, int pageSize) {

            ApplyPagination((pageIndex - 1) * pageSize, pageSize);
        }
    }
}
