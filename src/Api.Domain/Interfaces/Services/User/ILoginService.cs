using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}

