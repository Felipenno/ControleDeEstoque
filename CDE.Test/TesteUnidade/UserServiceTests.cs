using AutoFixture;
using AutoMapper;
using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Jwt;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using CDE.Service;
using CDE.Service.Cryptography;
using CDE.Service.Jwt;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CDE.Test.TesteUnidade
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConfiguration> _mockIConfiguration;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IUserService _userService;

        private readonly Fixture _fixture;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockIConfiguration = new Mock<IConfiguration>();

            _authenticationService = new AuthenticationService(_mockIConfiguration.Object);
            _cryptographyService = new CryptographyService();

            _userService = new UserService(_mockUserRepository.Object, _mockMapper.Object, _authenticationService, _cryptographyService);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task User_AddAsync()
        {
            var user = _fixture.Create<User>();
            var userRegisterViewModel = _fixture.Create<UserRegisterViewModel>();
            _mockMapper.Setup(m => m.Map<UserRegisterViewModel, User>(userRegisterViewModel)).Returns(user);
            _mockUserRepository.Setup(m => m.AddAsync(user)).ReturnsAsync(1);

            var errorMessage = await _userService.AddAsync(userRegisterViewModel);

            errorMessage.Should().BeNullOrEmpty();
            Mock.VerifyAll();
        }

        [Fact]
        public async Task User_EmailAlreadyExists()
        {
            var user = _fixture.Create<User>();
            _mockUserRepository.Setup(m => m.EmailAlreadyExists(user.UserEmail)).ReturnsAsync(user.UserEmail);

            var emailExists = await _userService.EmailAlreadyExists(user.UserEmail);

            emailExists.Should().BeFalse();
            Mock.VerifyAll();
        }

        [Fact]
        public async Task User_Login()
        {
            var userLoginViewModel = _fixture.Create<UserLoginViewModel>();
            var user = _fixture.Create<User>();
            var userJwtModel = _fixture.Create<UserJwtModel>();
            
            _mockIConfiguration.Setup(m => m.GetSection("JwtConfigurations:Secret").Value).Returns("abcdefghjnhlkn645645564668446844684664864646168sge8sges86gs8");
            _mockUserRepository.Setup(m => m.Login(userLoginViewModel)).ReturnsAsync(user);
            _mockMapper.Setup(m => m.Map<User, UserJwtModel>(user)).Returns(userJwtModel);

            var userJwt = await _userService.Login(userLoginViewModel);
            userJwtModel.Token = _authenticationService.Token(userJwt);

            userJwt.Should().BeOfType<UserJwtModel>();
            userJwtModel.Token.Should().NotBeNullOrEmpty();
            userJwt.Should().Be(userJwtModel);
            Mock.VerifyAll();

        }
    }
}
