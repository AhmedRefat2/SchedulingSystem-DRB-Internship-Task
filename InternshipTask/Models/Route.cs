namespace InternshipTask.Models
{
    public class Route : BaseEntity
    {
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
