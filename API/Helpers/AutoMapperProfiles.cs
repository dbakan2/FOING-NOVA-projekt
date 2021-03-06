using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<AppBill, BillDto>().ReverseMap();
            CreateMap<AppItem, ItemDto>().ReverseMap();

            // CreateMap<BillDto, AppBill>();
        }
    }
}