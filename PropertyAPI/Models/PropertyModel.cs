using PropertyAPI.Interfaces;
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

        public void CreateProperty(Property property)
        {
            PropertyService.CreateProperty(property);
        }

        public void UpdateProperty(Property property)
        {
            PropertyService.UpdateProperty(property);
        }

        public Property DeleteProperty(int id)
        {
            return PropertyService.DeleteProperty(id);
        }

    }
}