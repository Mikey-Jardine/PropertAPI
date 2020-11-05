using PropertyAPI.Entities;
using PropertyAPI.Interfaces;
using PropertyAPI.Responses;
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

        public IEnumerable<PropertyResponse> SearchResults { get; set; }

        public IPropertyService PropertyService { get; set; }

        public IEnumerable<PropertyResponse> GetAllProperties()
        {
            SearchResults = PropertyService.GetAllProperties();

            return SearchResults;
        }

        public PropertyResponse GetProperty(int id)
        {
            return PropertyService.GetProperty(id);
        }

        public IEnumerable<PropertyResponse> GetPropertyInRange(int low, int high)
        {
            SearchResults = PropertyService.GetPropertyInRange(low, high);

            return SearchResults;
        }

    }
}