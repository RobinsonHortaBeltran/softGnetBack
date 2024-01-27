#nullable enable
namespace SoftGnet.Models
{
    public class RoutesModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Driver_id { get; set; }
        public int Vehicle_id { get; set; }
        public bool Active { get; set; }
    }
}
