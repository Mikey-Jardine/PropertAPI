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
using Unity;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public SearchResultsModel SearchResults { get; set; }

        public PropertyModel PropertyModel { get; set; }

        public PropertyController(SearchResultsModel searchResults, PropertyModel propertyModel)
        {
            SearchResults = searchResults;
            PropertyModel = propertyModel;
        }

        // GET: api/Properties
        [HttpGet]
        public IEnumerable<Property> GetAllProperties()
        {
            return SearchResults.GetAllProperties();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public IActionResult GetProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = SearchResults.GetProperty(id);

            return Ok(property);
        }

        [HttpGet("{low}/{high}")]
        public IActionResult GetPropertyInRange([FromRoute] int low, int high)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var properties = SearchResults.GetPropertyInRange(low, high);

            return Ok(properties);
        }

        // PUT: api/Properties/5
        [HttpPut()]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PropertyModel.UpdateProperty(property);

            return NoContent();
        }

        // POST: api/Properties
        [HttpPost]
        public IActionResult CreateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PropertyModel.CreateProperty(property);

            return CreatedAtAction("GetProperty", new { id = property.Id }, property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = PropertyModel.DeleteProperty(id);

            return Ok(property);
        }

       
    }
}