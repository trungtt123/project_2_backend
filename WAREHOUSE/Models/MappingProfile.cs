using AutoMapper;
using WAREHOUSE.Entities;
namespace WAREHOUSE.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserInfomation>();
            CreateMap<User, UserEntity>();

        }
    }
}
