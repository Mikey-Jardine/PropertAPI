using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;
using PropertyAPI.Entities;


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
                var property = _context.Properties.Find(id);
                return property;
            }

            return null;
        }

        public List<Property> GetPropertyInRange(int low, int high)
        {
            var properties = _context.Properties.Where(x => x.Price >= low && x.Price <= high).ToList();

            return properties;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            var properties = _context.Properties;

            return properties;
        }

        public void CreateProperty(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            _context.Properties.Add(property);

            _context.SaveChanges();

        }

        public void UpdateProperty(Property property)
        {
            if (!PropertyExists(property.Id))
            {
                return;
            }
            _context.Properties.Add(property);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
              
            }
        }

        public Property DeleteProperty(int id)
        {
            if (!PropertyExists(id))
            {
                return null;
            }
            var propertyToDelete = _context.Properties.Find(id);

            _context.Properties.Remove(propertyToDelete);

            try
            {
                _context.SaveChanges();
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

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
