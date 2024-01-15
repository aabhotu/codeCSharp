using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace WebApplication2
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Owner, OwnerDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<OwnerForCreateDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
