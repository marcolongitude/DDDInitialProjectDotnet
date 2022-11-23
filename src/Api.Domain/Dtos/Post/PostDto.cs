using System;

namespace Api.Domain.Dtos.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}