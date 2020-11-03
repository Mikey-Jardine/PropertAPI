using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;
using Unity;

namespace PropertyAPI.Services
{
    public class PropertyService : IPropertyService
    {
        public PropertyService(IPropertyRepository propertyRepository)
        {
            PropertyRepository = propertyRepository;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return PropertyRepository.GetAllProperties();
        }

        public Property GetProperty(int id)
        {
            return PropertyRepository.GetProperty(id);
        }

        public List<Property> GetPropertyInRange(int low, int high)
        {  
            return PropertyRepository.GetPropertyInRange(low, high);
        }

        public void CreateProperty(Property property)
        {
            PropertyRepository.CreateProperty(property);
        }

        public void UpdateProperty(Property property)
        {
            PropertyRepository.UpdateProperty(property);
        }

        public Property DeleteProperty(int id)
        {
            return PropertyRepository.DeleteProperty(id);
        }

        public IPropertyRepository PropertyRepository { get; set; }
    }
}
