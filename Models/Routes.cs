namespace SoftGnet.Models;

public class Routes
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Driver_id { get; set; }
    public int Vehicle_id { get; set; }
    public bool Active { get; set; }

    public class Drivers
    {
        public int Id { get; set; }
        public List<Routes> Routes { get; set; }
    }

    public class Vehicles
    {
        public int Id { get; set; }
        public List<Routes> Routes { get; set; }
    }
}
    
    
