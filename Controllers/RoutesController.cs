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
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoutesRepository _routesRepository;
        public RoutesController(ApplicationDbContext context, RoutesRepository routesRepository)
        {
            _context = context;
            _routesRepository = routesRepository;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routes>>> GetRoutes()
        {
            return await _routesRepository.GetRoutesAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Routes>> GetRoutes(int id)
        {
            var routes = await _routesRepository.GetRouteAsync(id);

            if (routes == null)
            {
                return NotFound();
            }

            return routes;
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutes(int id, Routes routes)
        {
            if (id != routes.Id)
            {
                return BadRequest();
            }

            _context.Entry(routes).State = EntityState.Modified;

            try
            {
                await _routesRepository.PutRouteAsync(routes);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutesExists(id))
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

        // POST: api/Routes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Routes>> PostRoutes(Routes routes)
        {
            await _routesRepository.PostRouteAsync(routes);

            return CreatedAtAction("GetRoutes", new { id = routes.Id }, routes);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutes(int id)
        {
            var routes = await _context.Routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }

          await _routesRepository.DeleteRouteAsync(id);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoutesExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}
