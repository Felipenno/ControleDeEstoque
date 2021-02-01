using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDE.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel login)
        {
            try
            {
                var user = await _userService.Login(login);
                if (user != null)
                {
                    return Ok(user);
                }

                return BadRequest("Dados incorretos");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterViewModel register)
        {
            try
            {
                var erroMsg = await _userService.AddAsync(register);
                if (erroMsg == string.Empty)
                {
                    return Created("", register.UserName);
                }

                return BadRequest(erroMsg);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
