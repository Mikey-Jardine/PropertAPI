using PropertyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Entities;
using PropertyAPI.Requests;

namespace PropertyAPI.Interfaces
{
    public interface IPropertyModel
    {
        void CreateProperty(PropertyRequest property);
        void UpdateProperty(PropertyRequest property);
        PropertyRequest DeleteProperty(int id);


    }
}
