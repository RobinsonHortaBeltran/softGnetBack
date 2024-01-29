namespace SoftGnet.Models{
    public class Schedules{
        public int Id { get; set; }
        public string? Route_id { get; set; }
        public string? DayWeek_num { get; set; }
        public DateOnly From { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly To { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public bool Active { get; set; }
    }
}