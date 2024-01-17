using AutoMapper;
using RestApi.Data.DTO;
using RestApi.Entities.DTO;
using RestApi.Models;

namespace RestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, userDto > ();
            CreateMap<UserForUpdate, User>();
        }
    }
}
