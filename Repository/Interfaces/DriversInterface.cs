using SoftGnet.Models;
namespace SoftGnet.Repository.Interfaces;
public interface IDrivers
{
    Task<Drivers> GetDriverAsync(int id);
    Task<IEnumerable<Drivers>> GetAllDriversAsync();
    Task AddDriverAsync(Drivers driver);
    Task UpdateDriverAsync(Drivers driver);
    Task DeleteDriverAsync(int id);
}
