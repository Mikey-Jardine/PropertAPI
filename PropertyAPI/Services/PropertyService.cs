using AutoMapper;
using System.Collections.Generic;
using PropertyAPI.Interfaces;
using PropertyAPI.Entities;
using PropertyAPI.Responses;
using PropertyAPI.Requests;

namespace PropertyAPI.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IMapper _mapper;
        public PropertyResponse PropertyResponse { get; set; }
        public List<PropertyResponse> PropertyResponses { get; set; }

        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            PropertyRepository = propertyRepository;
            _mapper = mapper;
            PropertyResponses = new List<PropertyResponse>();
        }

        public IEnumerable<PropertyResponse> GetAllProperties()
        {
            var propertyEntities = PropertyRepository.GetAllProperties();
            foreach (var property in propertyEntities)
            {
                PropertyResponses.Add(_mapper.Map<PropertyResponse>(property));
            }
            return PropertyResponses;
        }

        public PropertyResponse GetProperty(int id)
        {
            var property = PropertyRepository.GetProperty(id);
            return _mapper.Map<PropertyResponse>(property);
        }

        public List<PropertyResponse> GetPropertyInRange(int low, int high)
        {
            var propertyEntities = PropertyRepository.GetPropertyInRange(low, high);
            foreach (var property in propertyEntities)
            {
                PropertyResponses.Add(_mapper.Map<PropertyResponse>(property));
            }
            return PropertyResponses;
        }

        public void CreateProperty(PropertyRequest property)
        {
            var prop = _mapper.Map<PropertyEntitiy>(property);
            PropertyRepository.CreateProperty(prop);
        }

        public void UpdateProperty(PropertyRequest property)
        {
            var prop = _mapper.Map<PropertyEntitiy>(property);
            PropertyRepository.UpdateProperty(prop);
        }

        public PropertyRequest DeleteProperty(int id)
        {
            var property = PropertyRepository.DeleteProperty(id);
            return _mapper.Map<PropertyRequest>(property);
        }

        public IPropertyRepository PropertyRepository { get; set; }
    }
}
