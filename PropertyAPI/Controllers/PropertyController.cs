using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Entities;
using PropertyAPI.Models;

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

        [HttpGet("/GetAllProperties")]
        public IEnumerable<Property> GetAllProperties()
        {
            return SearchResults.GetAllProperties();
        }

        [HttpGet("/GetProperty/{id}")]
        public IActionResult GetProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property = SearchResults.GetProperty(id);

            return Ok(property);
        }

        [HttpGet("/GetPropertyPriceRange{low}/{high}")]
        public IActionResult GetPropertyInRange([FromRoute] int low, int high)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var properties = SearchResults.GetPropertyInRange(low, high);

            return Ok(properties);
        }

        [HttpPut("/UpdateProperty")]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PropertyModel.UpdateProperty(property);

            return NoContent();
        }

        [HttpPost("/CreateProperty")]
        public IActionResult CreateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PropertyModel.CreateProperty(property);

            return CreatedAtAction("GetProperty", new { id = property.Id }, property);
        }

        [HttpDelete("/DeleteProperty/{id}")]
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