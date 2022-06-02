using AutoMapper;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.Models;

namespace IntranetApi.BusinessCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
        }
    }
}