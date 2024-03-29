using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DriversRepository _driversRepository;

        public DriversController(ApplicationDbContext context, DriversRepository driversRepository)
        {
            _context = context;
            _driversRepository = driversRepository;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
               return Ok(await _driversRepository.GetAllDriversAsync());
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers>> GetDrivers(int id)
        {
            var drivers = await _driversRepository.GetDriverAsync(id);

            if (drivers == null)
            {
                return NotFound();
            }

            return drivers;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrivers(int id, [FromBody] Drivers drivers)
        {
            if (id != drivers.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID del conductor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _driversRepository.UpdateDriverAsync(drivers);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Error al actualizar el conductor.");
                }
            }

            return Ok(drivers);
        }

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drivers>> PostDrivers(Drivers drivers)
        {
            await _driversRepository.AddDriverAsync(drivers);
            return CreatedAtAction("GetDrivers", new { id = drivers.Id }, drivers);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrivers(int id)
        {
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(drivers);
           

            return NoContent();
        }

        private bool DriversExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
