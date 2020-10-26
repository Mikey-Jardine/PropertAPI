using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Services
{
    public class PropertyService :  IPropertyService
    {
        private AppDBContext _context;


        public PropertyService(AppDBContext context) 
        {
            _context = context;
        }

        public Property GetProperty(int id)
        {
            if (PropertyExists(id))
            {
                return _context.Properties.Find(id);
            }

            return null;
        }

        public async Task<Property> UpdateProperty(Property property)
        {
            if (PropertyExists(property.Id))
            {
                _context.Entry(property).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.Id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return null;
        }

        public async Task<Property> CreateProperty(Property property)
        {
            if (!PropertyExists(property.Id))
            {
                _context.Properties.Add(@property);
                await _context.SaveChangesAsync();
            }

            return null;
        }

        public Task<Property> DeleteProperty(Property property)
        {
            if (PropertyExists(property.Id))
            {
                _context.Properties.Remove(property);
                _context.SaveChangesAsync();
            }

            return null;
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
