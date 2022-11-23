using System;

namespace Api.Domain.Dtos.Post
{
    public class PostDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}