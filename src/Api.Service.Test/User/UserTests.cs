using System;
using System.Collections.Generic;
using Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTests
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdate { get; set; }
        public static string UserEmailUpdate { get; set; }
        public static string UserCel { get; set; }
        public static string UserCelUpdate { get; set; }
        public static string UserPassword { get; set; }

        public static Guid UserId { get; set; }

        public List<UserDto> listUserDto = new List<UserDto>();

        public UserDto userDto;

        public UserDtoCreate userDtoCreate;

        public UserDtoCreateResult userDtoCreateResult;

        public UserDtoUpdate userDtoUpdate;

        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTests()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdate = Faker.Name.FullName();
            UserEmailUpdate = Faker.Internet.Email();
            UserCel = Faker.Identification.UKNationalInsuranceNumber();
            UserCelUpdate = Faker.Identification.UKNationalInsuranceNumber();
            UserPassword = Faker.RandomNumber.Next(100000, 100100).ToString();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Cel = Faker.Identification.UKNationalInsuranceNumber()
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                Cel = UserCel
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = UserName,
                Email = UserEmail,
                Password = UserPassword,
                Cel = UserCel
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                Cel = UserCel,
                CreateAt = DateTime.UtcNow,
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate,
                Cel = UserCelUpdate
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate,
                Cel = UserCelUpdate,
                UpdateAt = DateTime.UtcNow,
            };
        }

    }
}