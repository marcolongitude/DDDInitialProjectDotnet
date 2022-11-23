using System;

namespace Api.Domain.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity UserEntity { get; set; }

    }
}