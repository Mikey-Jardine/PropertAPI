using PropertyAPI.Entities;
using PropertyAPI.Responses;
using System.Collections.Generic;

namespace PropertyAPI.Interfaces
{
    public interface ISearchResultsModel
    {
        IEnumerable<PropertyResponse> GetAllProperties();
        PropertyResponse GetProperty(int id);
        IEnumerable<PropertyResponse> GetPropertyInRange(int low, int high);

    }
}
