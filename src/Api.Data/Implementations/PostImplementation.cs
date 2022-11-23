using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PostImplementation : BaseRepository<PostEntity>, IPostRepository
    {
        private DbSet<PostEntity> _dataset;
        public PostImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<PostEntity>();
        }
    }
}