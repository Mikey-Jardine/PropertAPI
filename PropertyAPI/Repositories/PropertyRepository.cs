using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public PropertyRepository(AppDBContext context)
        {
            _context = context;
        }

        private readonly AppDBContext _context;

        public Property GetProperty(int id)
        {
            if (PropertyExists(id))
            {
                return _context.Property.Find(id);
            }

            return null;
        }

        public IEnumerable<Property> GetAllProperty()
        {
            return _context.Property;
        }

        public void CreateProperty(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            _context.Property.Add(property);
            if (property.Photos != null && property.Photos.Count > 0)
            {
                foreach (var photo in property.Photos)
                {
                    _context.Photos.Add(photo);
                }

            }
            _context.SaveChangesAsync();

        }

        public void UpdateProperty(Property property)
        {
            if (PropertyExists(property.Id))
            {
                _context.Property.Add(property);

                if (property.Photos != null && property.Photos.Count > 0)
                {
                    foreach (var photo in property.Photos)
                    {
                        _context.Photos.Add(photo);
                    }

                }
                try
                {
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.Id))
                    {
                        
                    }
                    
                }
            }
        }

        public Property DeleteProperty(int id)
        {
            if (PropertyExists(id))
            {
                var propertyToDelete = _context.Property.Find(id);
                _context.Property.Remove(propertyToDelete);
                try
                {
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(id))
                    {
                        return null;
                    }

                }

                return propertyToDelete;
            }


            return null;
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.Id == id);
        }
    }
}
