using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;

namespace SoftGnet.Repository.Repositories
{
    public class VehiclesRepository : IVehicleInterface
    {
        private readonly ApplicationDbContext _context;

        public VehiclesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateVehiclesAsync(Vehicles vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehiclesAsync(Vehicles vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

       

        public async Task<List<Vehicles>> GetAllVehiclesAsync()
        {
           return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicles> GetVehiclesAsyncById(int vehicleId)
        {
            return await _context.Vehicles.FindAsync(vehicleId) ?? throw new Exception("Vehicle not found.");
        }

        public async Task UpdateVehiclesAsync(Vehicles vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}