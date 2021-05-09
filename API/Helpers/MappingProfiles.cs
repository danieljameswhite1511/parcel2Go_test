
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();
    
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();
            
        }
    }
}