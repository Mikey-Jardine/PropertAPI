using PropertyAPI.Entities;
using PropertyAPI.Interfaces;
using PropertyAPI.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Models
{
    public class PropertyModel : IPropertyModel
    {
        public PropertyModel(IPropertyService propertyService)
        {
            PropertyService = propertyService;
        }

        public IPropertyService PropertyService { get; set; }

        public void CreateProperty(PropertyRequest property)
        {
            PropertyService.CreateProperty(property);
        }

        public void UpdateProperty(PropertyRequest property)
        {
            PropertyService.UpdateProperty(property);
        }

        public PropertyRequest DeleteProperty(int id)
        {
            return PropertyService.DeleteProperty(id);
        }

    }
}