using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.Users;
using MovieApp.Services;
using MovieApp.Shared;
using MovieApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWorkshop_MovieApp.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterModel userRegisterModel)
        {
            try
            {
                _userService.Register(userRegisterModel);
                return StatusCode(StatusCodes.Status201Created, "User registered successfully");
            }
            catch (UserException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            try
            {
                _userService.Login(userLoginModel);
                return StatusCode(StatusCodes.Status200OK, $"Welcome {userLoginModel.Username}");
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

