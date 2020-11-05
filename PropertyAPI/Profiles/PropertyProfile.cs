using AutoMapper;
using PropertyAPI.Responses;
using PropertyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyResponse>()
                .ForMember(dest =>
                    dest.Photos, 
                    opt => opt.MapFrom(src => src.PhotosCollection
                    .Select(x => x.Url)));
        }
    }
}
