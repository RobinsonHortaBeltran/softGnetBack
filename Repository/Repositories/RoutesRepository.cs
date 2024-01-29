using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async Task<RoutesModel> DeleteRouteAsync(int id)
        {
            var route = await _context.RoutesModel.FindAsync(id);
            _context.RoutesModel.Remove(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<RoutesModel> GetRouteAsync(int id)
        {
            var route = await _context.RoutesModel.FindAsync(id);
            return route ?? throw new Exception("Route not found.");
        }

        public async Task<List<RoutesModel>> GetRoutesAsync()
        {
            return await _context.RoutesModel.ToListAsync();
        }

        public async Task<RoutesModel> PostRouteAsync(RoutesModel route)
        {
            await _context.RoutesModel.AddAsync(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<RoutesModel> PutRouteAsync(RoutesModel route)
        {
            _context.RoutesModel.Update(route);
            await _context.SaveChangesAsync();
            return route;
        }

    }
}