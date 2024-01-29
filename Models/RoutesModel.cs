#nullable enable
namespace SoftGnet.Models
{
    public class RoutesModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? DriverId { get; set; }
        public string? VehicleId { get; set; }
        public bool Active { get; set; }
    }
}
