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
        void CreateProperty(PropertyEntitiy property);
        void UpdateProperty(PropertyEntitiy property);
        PropertyEntitiy DeleteProperty(int id);


    }
}
