using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Models;

namespace PropertyAPI.Interfaces
{
    public interface IPropertyRepository
    {
        Property GetProperty(int id);
        List<Property> GetPropertyInRange(int low, int high);
        IEnumerable<Property> GetAllProperty();
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        Property DeleteProperty(int id);

    }
}
