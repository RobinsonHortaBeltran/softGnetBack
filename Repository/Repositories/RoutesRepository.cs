using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using SoftGnet.Repository.Interfaces;

namespace SoftGnet.Repository.Repositories
{
    public class RoutesRepository : IRoutesInterface
    {
        private readonly ApplicationDbContext _context;

        public RoutesRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<Routes> DeleteRouteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<Routes> GetRouteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            return route ?? throw new Exception("Route not found.");
        }

        public async Task<List<Routes>> GetRoutesAsync()
        {
            return await _context.Routes.ToListAsync();
        }

        public async Task<Routes> PostRouteAsync(Routes route)
        {
            await _context.Routes.AddAsync(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<Routes> PutRouteAsync(Routes route)
        {
            _context.Routes.Update(route);
            await _context.SaveChangesAsync();
            return route;
        }
    }
}