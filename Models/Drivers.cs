
namespace SoftGnet.Models;

public class Drivers{
    public int Id { get; set; }
    public string? Last_name { get; set; }
    public string? First_name { get; set; }
    public string? Ssn { get; set; }
    public DateOnly Dod { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public int Phone { get; set; }
    public bool Active { get; set; }

    public List<RoutesModel> Routes { get; set; } = new List<RoutesModel>();
}