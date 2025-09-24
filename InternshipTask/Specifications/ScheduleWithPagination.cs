using InternshipTask.Models;
using Talabat.Core.Specifications;

namespace InternshipTask.Specifications
{
    public class ScheduleWithPagination : BaseSpecifications<Schedule>
    {


        public ScheduleWithPagination(int driverId, int pageIndex, int pageSize) : base(S => S.DriverId == driverId)
        {
            AddIncludes();
            ApplyPagination((pageIndex - 1) * pageSize, pageSize);
        }

        private void AddIncludes()
        {
            Includes.Add(s => s.Route);
        }
    }
}
