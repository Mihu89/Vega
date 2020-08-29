using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly VegaDbContext _context;

        public VehicleController(IMapper mapper, VegaDbContext context)
        {                 
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            _mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);

            vehicle.LastUpdate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        }
}