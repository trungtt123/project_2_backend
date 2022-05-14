using AutoMapper;
using WareHouse.Core.Entities;
namespace WareHouse.Core.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserInfomationDto>();
            CreateMap<UserEntity, UserDataDto>();
            CreateMap<UserNoIdDto, UserEntity>();
            CreateMap<UserNoIdDto, UserInfomationDto>();
            CreateMap<UserUpdateDto, UserInfomationDto>();
            CreateMap<UserUpdateDto, UserEntity>();
            CreateMap<RoleEntity, RoleDto>();
        }
    }
}
