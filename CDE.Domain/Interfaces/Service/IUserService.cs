using CDE.Domain.ViewModels;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<string> AddAsync(UserRegisterViewModel userRegister);
        Task<bool> EmailAlreadyExists(string email);
        Task<object> Login(UserLoginViewModel userLoginViewModel);
    }
}
