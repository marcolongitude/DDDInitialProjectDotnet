using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Entities;
using Domain.Dtos.User;
using Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseServiceTest
    {
        [Fact(DisplayName = "User Mapper Test")]
        public void UserMapperTest()
        {
            UserModel model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            List<UserEntity> listEntity = new List<UserEntity>();

            for (int i = 0; i < 5; i++)
            {
                UserEntity item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                };

                listEntity.Add(item);
            }

            //Model to Entity
            UserEntity dtoToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);

            //Entity to DTO
            UserDto userDto = Mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(userDto.Id, dtoToEntity.Id);
            Assert.Equal(userDto.Name, dtoToEntity.Name);
            Assert.Equal(userDto.Email, dtoToEntity.Email);
            Assert.Equal(userDto.CreateAt, dtoToEntity.CreateAt);

            List<UserDto> listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }
        }
    }
}