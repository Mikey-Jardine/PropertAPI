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
                var property = _context.Properties.Find(id);
                return JoinPropertyAndPhotos(property); 
            }

            return null;
        }

        public List<Property> GetPropertyInRange(int low, int high)
        {
            var properties = _context.Properties.Where(x => x.Price >= low && x.Price <= high).ToList();
            foreach (var property in properties)
            {
                JoinPropertyAndPhotos(property);
            }
            return properties;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            var properties = _context.Properties;
            foreach (var property in properties)
            {
                JoinPropertyAndPhotos(property);
            }
            return properties;
        }

        public void CreateProperty(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            _context.Properties.Add(property);
            if (property.Photos != null && property.Photos.Count > 0)
            {
                foreach (var photo in property.Photos)
                {
                    _context.Photos.Add(new Photo { PropertyId = property.Id, Url = photo });
                }
            }
            _context.SaveChanges();

        }

        public void UpdateProperty(Property property)
        {
            if (!PropertyExists(property.Id))
            {
                return;
            }
            _context.Properties.Add(property);

            if (property.Photos != null && property.Photos.Count > 0)
            {
                foreach (var photo in property.Photos)
                {
                    if (!PhotoExists(photo))
                    {
                        _context.Photos.Add(new Photo { PropertyId = property.Id, Url = photo });
                    }
                }
            }
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
            var photosToDelete = _context.Photos.Where(x => x.PropertyId == id);

            _context.Properties.Remove(propertyToDelete);
            _context.Photos.RemoveRange(photosToDelete);

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

        private Property JoinPropertyAndPhotos(Property property)
        {
            foreach (var photo in _context.Photos.Where(x => x.PropertyId == property.Id))
            {
                if (property.Photos == null || property.Photos.Contains(photo.Url))
                {
                    continue;
                }
                property.Photos.Add(photo.Url);
            }
            return property;
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }

        private bool PhotoExists(string url)
        {
            return _context.Photos.Any(e => e.Url == url);
        }
    }
}
