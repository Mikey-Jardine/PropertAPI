using PropertyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Interfaces
{
    public interface ISearchResultsModel
    {
        IEnumerable<Property> GetAllProperties();
        Property GetProperty(int id);
        IEnumerable<Property> GetPropertyInRange(int low, int high);

    }
}
