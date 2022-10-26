using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Domain.Repository
{
    public interface IUserRepository: IRepository<UserEntity> {
        Task<UserEntity> FindByLogin ( string email, string Password );
    }
}