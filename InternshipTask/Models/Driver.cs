namespace InternshipTask.Models
{
    public class Driver : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;
        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    }
}
