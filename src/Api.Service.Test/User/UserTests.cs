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

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreatedAt = DateTime.UtcNow,
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                UpdateAt = DateTime.UtcNow,
            };
        }

    }
}