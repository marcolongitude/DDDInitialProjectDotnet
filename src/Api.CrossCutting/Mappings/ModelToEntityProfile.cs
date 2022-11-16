using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<PostEntity, PostModel>().ReverseMap();
        }
    }
}