using SoftGnet.Models;

namespace SoftGnet.Repository.Interfaces
{
    public interface IRoutesInterface
    {
        public Task<List<RoutesModel>> GetRoutesAsync();
        public Task<RoutesModel> GetRouteAsync(int id);
        public Task<RoutesModel> PostRouteAsync(RoutesModel route);
        public Task<RoutesModel> PutRouteAsync(RoutesModel route);
        public Task<RoutesModel> DeleteRouteAsync(int id);
    }
}