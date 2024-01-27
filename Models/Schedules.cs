namespace SoftGnet.Models{
    public class Schedules{
        public int Id { get; set; }
        public int Route_id { get; set; }
        public int DayWeek_num { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Active { get; set; }
    }
}