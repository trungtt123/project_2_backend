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
            CreateMap<ProductTypeEntity, ProductTypeDto>();
            CreateMap<ProductBatchEntity, ProductBatchDto>();
            CreateMap<ProductTypeDto, ProductTypeEntity>();
            CreateMap<ProductBatchDto, ProductBatchEntity>();
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductNoIdDto, ProductEntity>();
            CreateMap<ProductBatchNoIdDto, ProductBatchEntity>();

            CreateMap<InputInfoEntity, InputInfoDto>();
            CreateMap<InputInfoNoIdDto, InputInfoEntity>();

            

        }
    }
}
