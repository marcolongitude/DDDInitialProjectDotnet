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
                Cel = Faker.Identification.UKNationalInsuranceNumber().ToString(),
                Password = Faker.RandomNumber.Next(100000, 100100).ToString(),
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
                    Cel = Faker.Identification.UKNationalInsuranceNumber().ToString(),
                    Password = Faker.RandomNumber.Next(100000, 100100).ToString(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                };

                listEntity.Add(item);
            }

            //Model to Entity
            UserEntity entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.Cel, model.Cel);
            Assert.Equal(entity.Password, model.Password);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity to DTO
            UserDto userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.Cel, entity.Cel);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);

            List<UserDto> listDto = Mapper.Map<List<UserDto>>(listEntity);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].Cel, listEntity[i].Cel);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }

            UserDtoCreateResult userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);
            Assert.Equal(userDtoCreateResult.Email, entity.Email);
            Assert.Equal(userDtoCreateResult.Cel, entity.Cel);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

            UserDtoUpdateResult userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.Email, entity.Email);
            Assert.Equal(userDtoUpdateResult.Cel, entity.Cel);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto to Model
            UserModel userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.Cel, userDto.Cel);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);

            UserDtoCreate userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);
            Assert.Equal(userDtoCreate.Cel, userModel.Cel);
            Assert.Equal(userDtoCreate.Password, userModel.Password);

            UserDtoUpdate userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
            Assert.Equal(userDtoUpdate.Cel, userModel.Cel);
        }
    }
}