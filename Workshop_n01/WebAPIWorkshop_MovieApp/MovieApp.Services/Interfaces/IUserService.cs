using MovieApp.Models;
using MovieApp.Models.Users;
using System;

namespace MovieApp.Services
{
    public interface IUserService
    {
        void Register(UserRegisterModel UserRegisterModel);
        string Login(UserLoginModel userLoginModel);

    }
}
