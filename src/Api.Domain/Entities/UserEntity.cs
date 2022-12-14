using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public enum Roles
    {
        admin,
        common
    }
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cel { get; set; }
        public Roles Permission { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }

    }
}