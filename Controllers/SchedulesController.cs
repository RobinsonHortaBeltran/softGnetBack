using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftGnet.Models;
using SoftGnet.Repository.Repositories;

namespace SoftGnet.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SchedulesRepository _schedulesRepository;

        public SchedulesController(ApplicationDbContext context, SchedulesRepository schedulesRepository)
        {
            _context = context;
            _schedulesRepository = schedulesRepository;
            
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedules>>> GetSchedules()
        {
            var schedules = await _schedulesRepository.GetAllAsync();
            return Ok(schedules);
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedules>> GetSchedules(int id)
        {
            var schedules = await _schedulesRepository.GetByIdAsync(id);

            if (schedules == null)
            {
                return NotFound();
            }

            return schedules;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedules(int id, Schedules schedules)
        {
            if (id != schedules.Id)
            {
                return BadRequest();
            }

            await _schedulesRepository.UpdateAsync(schedules);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedulesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedules>> PostSchedules(Schedules schedules)
        {
           await _schedulesRepository.CreateAsync(schedules);
        

            return CreatedAtAction(nameof(GetSchedules), new { id = schedules.Id }, schedules);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedules(int id)
        {
            var schedules = await _schedulesRepository.GetByIdAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedules);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
