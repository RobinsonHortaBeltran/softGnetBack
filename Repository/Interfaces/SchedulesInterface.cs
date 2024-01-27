using System.Collections.Generic;
using System.Threading.Tasks;
using SoftGnet.Models;
namespace SoftGnet.Repository.Interfaces
{

    public interface ISchedulesInterface
    {
        Task<IEnumerable<Schedules>> GetAllAsync();
        Task<Schedules> GetByIdAsync(int id);
        Task CreateAsync(Schedules schedule);
        Task UpdateAsync(Schedules schedule);
        Task DeleteAsync(int id);
    }
}