using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Post;

namespace Api.Domain.Interfaces.Services.Post
{
    public interface IPostService
    {
        Task<PostDto> Get(Guid id);
        Task<IEnumerable<PostDto>> GetAll();
        Task<PostDtoCreateResult> Post(PostDtoCreate post);
        Task<PostDtoUpdateResult> Put(PostDtoUpdate post);
        Task<bool> Delete(Guid id);
    }
}