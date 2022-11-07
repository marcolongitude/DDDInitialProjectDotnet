using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Utils.Functions;
using Xunit;

namespace Api.Utils.Test
{
    public class PasswordHashedTest
    {
        private string password { get; set; }
        private string passwordHashed { get; set; }
        private bool passwordVerified { get; set; }

        [Fact(DisplayName = "Password Hashed Teste")]
        public void PasswordHashedTestUnity()
        {
            password = Faker.RandomNumber.Next(100000, 100100).ToString();

            passwordHashed = PasswordHashed.HashPassword(password);
            passwordVerified = PasswordHashed.VerifyHashedPassword(passwordHashed, password);

            Assert.True(passwordVerified);
        }
    }
}