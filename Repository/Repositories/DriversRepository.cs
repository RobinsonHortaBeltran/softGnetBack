using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using SoftGnet.Repository.Interfaces;

namespace SoftGnet.Repository.Repositories
{
    public class DriversRepository : IDrivers
    {
        private readonly ApplicationDbContext _context;
        public DriversRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDriverAsync(Drivers driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDriverAsync(int id)
        {
            var driver = await GetDriverAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<Drivers> GetDriverAsync(int id)
        {
            return await _context.Drivers.FindAsync(id) ?? throw new Exception("Driver not found.");
        }

        public async Task<IEnumerable<Drivers>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task UpdateDriverAsync(Drivers driver)
        {
            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();
        }
    }
}