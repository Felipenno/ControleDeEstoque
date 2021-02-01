using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Jwt;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using System.Threading.Tasks;

namespace CDE.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IUserRepository userRepository, IMapper mapper, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<string> AddAsync(UserRegisterViewModel userRegister)
        {
            if(await EmailAlreadyExists(userRegister.UserEmail))
            {
                return "Esse email ja está cadastrado";
            }

            var user = _mapper.Map<UserRegisterViewModel, User>(userRegister);
            user.EncryptPassword();

            var affectedRows = await _userRepository.AddAsync(user);
            if (affectedRows <= 0)
            {
                return "Erro ao cadastrar";
            }

            return string.Empty;
        }

        public async Task<bool> EmailAlreadyExists(string email)
        {
            var emailReceived = await _userRepository.EmailAlreadyExists(email);
            if (string.IsNullOrEmpty(emailReceived))
            {
                return false;
            }

            return true;
        }

        public async Task<object> Login(UserLoginViewModel userLoginViewModel)
        {
            userLoginViewModel.EncryptPassword();
            var user = await _userRepository.Login(userLoginViewModel);
            if (user == null)
            {
                return null;
            }

            var userJwt = _mapper.Map<User, UserJwtModel>(user);
            var token = _authenticationService.Token(userJwt);

            return new { Token = token, Usuario = userJwt };
        }
    }
}
