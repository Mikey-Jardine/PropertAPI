using PropertyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Entities;

namespace PropertyAPI.Interfaces
{
    public interface ICreatePropertyModel
    {
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        Property DeleteProperty(int id);


    }
}
