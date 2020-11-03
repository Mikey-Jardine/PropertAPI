using PropertyAPI.Entities;
using System.Collections.Generic;

namespace PropertyAPI.Interfaces
{
    public interface ISearchResultsModel
    {
        IEnumerable<Property> GetAllProperties();
        Property GetProperty(int id);
        IEnumerable<Property> GetPropertyInRange(int low, int high);

    }
}
