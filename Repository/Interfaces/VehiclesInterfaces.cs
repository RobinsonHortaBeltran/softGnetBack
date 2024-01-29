using SoftGnet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVehicleInterface
{
    Task CreateVehiclesAsync(Vehicles vehicle);
    Task UpdateVehiclesAsync(Vehicles vehicle);
    Task DeleteVehiclesAsync(Vehicles vehicle);
    Task<Vehicles> GetVehiclesAsyncById(int vehicleId);
    Task<List<Vehicles>> GetAllVehiclesAsync();
}
