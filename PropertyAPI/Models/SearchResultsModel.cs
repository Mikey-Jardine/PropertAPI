using PropertyAPI.Entities;
using PropertyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Models
{
    public class SearchResultsModel : ISearchResultsModel
    {
        public SearchResultsModel(IPropertyService propertyService)
        {
            PropertyService = propertyService;
        }

        public IEnumerable<Property> SearchResults { get; set; }

        public IPropertyService PropertyService { get; set; }

        public IEnumerable<Property> GetAllProperties()
        {
            SearchResults = PropertyService.GetAllProperties();

            return SearchResults;
        }

        public Property GetProperty(int id)
        {
            return PropertyService.GetProperty(id);
        }

        public IEnumerable<Property> GetPropertyInRange(int low, int high)
        {
            SearchResults = PropertyService.GetPropertyInRange(low, high);

            return SearchResults;
        }
    }
}