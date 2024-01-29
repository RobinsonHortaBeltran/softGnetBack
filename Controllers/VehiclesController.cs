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
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly VehiclesRepository _vehiclesRepository;
        public VehiclesController(ApplicationDbContext context, VehiclesRepository vehiclesRepository)
        {
            _context = context;
            _vehiclesRepository = vehiclesRepository;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicles>>> GetVehicles()
        {
            return await _vehiclesRepository.GetAllVehiclesAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> GetVehicles(int id)
        {
            var vehicles = await _vehiclesRepository.GetVehiclesAsyncById(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicles(int id, [FromBody] Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID del conductor.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vehiclesRepository.UpdateVehiclesAsync(vehicles);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Error al actualizar el vehiculo.");
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicles>> PostVehicles(Vehicles vehicles)
        {
            await _vehiclesRepository.CreateVehiclesAsync(vehicles);

            return CreatedAtAction(nameof(GetVehicles), new { id = vehicles.Id }, vehicles);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicles(int id)
        {
            var vehicles = await _vehiclesRepository.GetVehiclesAsyncById(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            await _vehiclesRepository.DeleteVehiclesAsync(vehicles);

            return NoContent();
        }

        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
