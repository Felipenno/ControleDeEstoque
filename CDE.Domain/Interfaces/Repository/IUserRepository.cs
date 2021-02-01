using CDE.Domain.Entities;
using CDE.Domain.ViewModels;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<int> AddAsync(User user);
        Task<string> EmailAlreadyExists(string email);
        Task<User> Login(UserLoginViewModel userLoginViewModel);
    }
}
