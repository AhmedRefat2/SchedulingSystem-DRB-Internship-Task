using InternshipTask.Repository;

namespace InternshipTask.Controllers
{
    public class RoutesController : BaseController<Models.Route>
    {
        private readonly IGenericRepositoy<Models.Route> _routeRepo;
        public RoutesController(IGenericRepositoy<Models.Route> routeRepo) : base(routeRepo)
        {
            _routeRepo = routeRepo;
        }
    }
}
