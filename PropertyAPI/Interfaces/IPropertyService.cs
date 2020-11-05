using PropertyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Entities;
using PropertyAPI.Responses;
using PropertyAPI.Requests;

namespace PropertyAPI.Interfaces
{
    public interface IPropertyService
    {
        IEnumerable<PropertyResponse> GetAllProperties();
        PropertyResponse GetProperty(int id);
        List<PropertyResponse> GetPropertyInRange(int low, int high);
        void CreateProperty(PropertyRequest property);
        void UpdateProperty(PropertyRequest property);
        PropertyRequest DeleteProperty(int id);


    }
}
