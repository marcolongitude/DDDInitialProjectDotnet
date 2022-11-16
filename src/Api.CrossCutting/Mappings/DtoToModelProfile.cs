using Api.Domain.Dtos.Post;
using Api.Domain.Models;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();

            CreateMap<PostModel, PostDto>().ReverseMap();
            CreateMap<PostModel, PostDtoCreate>().ReverseMap();
            CreateMap<PostModel, PostDtoUpdate>().ReverseMap();
        }
    }
}