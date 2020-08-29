using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}