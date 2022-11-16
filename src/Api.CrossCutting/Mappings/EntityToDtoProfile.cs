using Api.Domain.Dtos.Post;
using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.User;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

            CreateMap<PostDto, PostEntity>().ReverseMap();
            CreateMap<PostDtoCreateResult, PostEntity>().ReverseMap();
            CreateMap<PostDtoUpdateResult, PostEntity>().ReverseMap();
        }
    }
}