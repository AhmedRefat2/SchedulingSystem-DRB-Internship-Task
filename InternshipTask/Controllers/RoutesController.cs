using InternshipTask.Repository;
using InternshipTask.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.Controllers
{
    public class RoutesController : BaseController<Models.Route>
    {
        private readonly IGenericRepositoy<Models.Route> _routeRepo;
        public RoutesController(IGenericRepositoy<Models.Route> routeRepo) : base(routeRepo)
        {
            _routeRepo = routeRepo;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllPaged(int pageIndex = 1, int pageSize = 10)
        {
            var specs = new RoutesWithPaginationSpecs(pageIndex, pageSize);
            var Routes = await _routeRepo.GetAllWithSpecAsync(specs);
            return Ok(Routes);
        }
    }
}
