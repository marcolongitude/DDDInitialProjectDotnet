using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Post;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Post;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PostService : IPostService
    {
        private IRepository<PostEntity> _repository;
        private readonly IMapper _mapper;
        public async Task<bool> Delete(Guid id)
        {
            PostEntity postExists = await _repository.SelectAsync(id);

            if (postExists == null)
            {
                throw new ArgumentNullException("post not exists");
            }

            return await _repository.DeleteAsync(id);
        }

        public async Task<PostDto> Get(Guid id)
        {
            PostEntity entity = await _repository.SelectAsync(id);
            return _mapper.Map<PostDto>(entity) ?? null;
        }

        public async Task<IEnumerable<PostDto>> GetAll()
        {
            IEnumerable<PostEntity> listPostsEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PostDto>>(listPostsEntity);
        }

        public async Task<PostDtoCreateResult> Post(PostDtoCreate post)
        {
            PostModel model = _mapper.Map<PostModel>(post);
            PostEntity entity = _mapper.Map<PostEntity>(model);
            PostEntity result = await _repository.InsertAsync(entity);

            return _mapper.Map<PostDtoCreateResult>(result);
        }

        public async Task<PostDtoUpdateResult> Put(PostDtoUpdate post)
        {
            var postExists = await _repository.SelectAsync(post.Id);

            if (postExists == null)
            {
                throw new ArgumentNullException("user not exists");
            }

            PostModel model = _mapper.Map<PostModel>(post);
            PostEntity entity = _mapper.Map<PostEntity>(model);
            PostEntity result = await _repository.UpdateAsync(entity);

            return _mapper.Map<PostDtoUpdateResult>(result);
        }
    }
}