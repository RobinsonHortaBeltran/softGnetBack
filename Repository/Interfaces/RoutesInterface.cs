using SoftGnet.Models;

namespace SoftGnet.Repository.Interfaces
{
    public interface IRoutesInterface
    {
        public Task<List<Routes>> GetRoutesAsync();
        public Task<Routes> GetRouteAsync(int id);
        public Task<Routes> PostRouteAsync(Routes route);
        public Task<Routes> PutRouteAsync(Routes route);
        public Task<Routes> DeleteRouteAsync(int id);
    }
}