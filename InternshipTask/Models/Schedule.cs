namespace InternshipTask.Models
{
    public enum ScheduleStatus
    {
        Scheduled,
        Completed,
        Cancelled
    }

    public class Schedule : BaseEntity
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        public int RouteId { get; set; }
        public Route Route { get; set; } = null!;
        public DateTime Date { get; set; }
        public ScheduleStatus Status { get; set; }

    }
}
