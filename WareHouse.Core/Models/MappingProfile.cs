using AutoMapper;
using WareHouse.Core.Entities;
namespace WareHouse.Core.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserInfomation>();
            CreateMap<UserEntity, UserData>();
            CreateMap<UserNoId, UserEntity>();
            CreateMap<UserNoId, UserInfomation>();
            CreateMap<UserUpdate, UserInfomation>();
            CreateMap<UserUpdate, UserEntity>();
            CreateMap<RoleEntity, RoleDto>();
        }
    }
}
