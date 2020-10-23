using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPropertyRepository _propertyRepository;

        public PropertiesController(AppDBContext context, IPropertyRepository propertyRepository)
        {
            _context = context;
            _propertyRepository = propertyRepository;
        }

        // GET: api/Properties
        [HttpGet]
        public IEnumerable<Property> GetProperty()
        {
            return _propertyRepository.GetAllProperty();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property =_propertyRepository.GetProperty(id);

            return Ok(property);
        }

        [HttpGet("{low}/{high}")]
        public async Task<IActionResult> GetPropertyInRange([FromRoute] int low, int high)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var properties = _propertyRepository.GetPropertyInRange(low, high);

            return Ok(properties);
        }

        // PUT: api/Properties/5
        [HttpPut()]
        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _propertyRepository.CreateProperty(property);

            return NoContent();
        }

        // POST: api/Properties
        [HttpPost]
        public async Task<IActionResult> UpdateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _propertyRepository.UpdateProperty(property);

            return CreatedAtAction("GetProperty", new { id = property.Id }, property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = _propertyRepository.DeleteProperty(id);

            return Ok(property);
        }


    }
}