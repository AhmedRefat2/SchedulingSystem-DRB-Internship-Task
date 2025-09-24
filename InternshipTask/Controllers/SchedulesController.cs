using InternshipTask.Data;
using InternshipTask.Models;
using InternshipTask.Repository;
using InternshipTask.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternshipTask.Controllers
{
    public class SchedulesController : BaseController<Schedule>
    {
        private readonly IGenericRepositoy<Schedule> _scheduleRepo;

        public SchedulesController(IGenericRepositoy<Schedule> scheduleRepo) : base(scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        [HttpPost("assign")]
        public async Task<ActionResult<Schedule>> AssignDriver([FromBody] Schedule schedule)
        {
            // check availability
            var existing = (await _scheduleRepo.GetAllAsync())
                            .Any(s => s.DriverId == schedule.DriverId && s.Date.Date == schedule.Date.Date);
            
            if (existing)
                return BadRequest("Driver is not available on this date.");

            await _scheduleRepo.AddAsync(schedule);
            await _scheduleRepo.SaveAsync();

            return Ok(schedule);
        }


        [HttpGet("driver/{driverId}/history")]
        public async Task<IActionResult> GetDriverHistory(int driverId, int pageIndex, int pagSize)
        {
            var specs = new ScheduleWithPagination(driverId, pageIndex, pagSize);
            var schedules = await _scheduleRepo.GetAllWithSpecAsync(specs);
            return Ok(schedules);
        }
    }
}
