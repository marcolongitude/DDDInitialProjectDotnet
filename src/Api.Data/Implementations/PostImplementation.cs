using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class PostImplementation : BaseRepository<PostEntity>
    {
        private DbSet<PostEntity> _dataset;
        public PostImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<PostEntity>();
        }
    }
}