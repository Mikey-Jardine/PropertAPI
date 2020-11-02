using PropertyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Interfaces
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetAllProperty();
        Property GetProperty(int id);
        List<Property> GetPropertyInRange(int low, int high);
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        Property DeleteProperty(int id);


    }
}
