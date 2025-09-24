using InternshipTask.Models;
using InternshipTask.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController<Driver>
    {
        private readonly IGenericRepositoy<Driver> _driverRepo;

        public DriversController(IGenericRepositoy<Driver> driverRepo) : base(driverRepo)
        {
            _driverRepo = driverRepo;
        }
    }
}
