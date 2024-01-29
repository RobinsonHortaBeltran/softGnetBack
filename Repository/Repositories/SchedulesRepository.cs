using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using SoftGnet.Repository.Interfaces;

namespace SoftGnet.Repository.Repositories
{
    public class SchedulesRepository : ISchedulesInterface
    {
        private readonly ApplicationDbContext _context;

        public SchedulesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Schedules schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var schedule = await this.GetByIdAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Schedules>> GetAllAsync()
        {
           return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedules> GetByIdAsync(int id)
        {
            return await _context.Schedules.FindAsync(id) ?? throw new System.Exception("Schedule not found");
        }

        public async Task UpdateAsync(Schedules schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
    }
}