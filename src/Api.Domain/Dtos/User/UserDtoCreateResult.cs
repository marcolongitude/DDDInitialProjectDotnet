using System;

namespace Domain.Dtos.User
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cel { get; set; }
        public string Permission { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

