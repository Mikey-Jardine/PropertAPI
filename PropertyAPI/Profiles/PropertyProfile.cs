using AutoMapper;
using PropertyAPI.Responses;
using PropertyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Requests;

namespace PropertyAPI.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<PropertyEntitiy, PropertyResponse>()
                .ForMember(dest =>
                    dest.Photos, 
                    opt => opt.MapFrom(src => src.PhotosCollection
                    .Select(x => x.Url)));

            CreateMap<PropertyRequest, PropertyEntitiy>()
               .ForMember(dest =>
                   dest.PhotosCollection.Select(x => x.Url),
                   opt => opt.MapFrom(src => src.Photos));

            CreateMap<PropertyRequest, PropertyEntitiy>()
               .ForMember(dest =>
                   dest.PhotosCollection.Select(x => x.PropertyId),
                   opt => opt.MapFrom(src => src.Id));

        }
    }
}
