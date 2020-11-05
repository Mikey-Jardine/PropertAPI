using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Models;
using PropertyAPI.Entities;


namespace PropertyAPI.Interfaces
{
    public interface IPropertyRepository
    {
        PropertyEntitiy GetProperty(int id);
        List<PropertyEntitiy> GetPropertyInRange(int low, int high);
        IEnumerable<PropertyEntitiy> GetAllProperties();
        void CreateProperty(PropertyEntitiy property);
        void UpdateProperty(PropertyEntitiy property);
        PropertyEntitiy DeleteProperty(int id);

    }
}
