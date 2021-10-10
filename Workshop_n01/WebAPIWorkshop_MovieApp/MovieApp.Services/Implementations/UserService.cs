using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.Models;
using MovieApp.Models.Users;
using MovieApp.Shared;
using MovieApp.Shared.CustomEntities;
using MovieApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieApp.Services.Implementations
{
    public class UserService : IUserService
    {   
        private IUserRepository _userRepository;
        private IOptions<AppSettings> _options;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }
        public string Login(UserLoginModel userLoginModel)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(userLoginModel.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            User userDb = _userRepository.LoginUser(userLoginModel.Username, hashedPassword);
            if (userDb == null)
            {
                throw new NotFoundException($"User with username {userLoginModel.Username} cannot be found");
            }

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                //signature definition
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                    {
                            new Claim(ClaimTypes.Name, userDb.Username),
                            new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                            new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                    }
                )
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            // convert it to string
            string tokenString = jwtSecurityTokenHandler.WriteToken(token);
            return tokenString;
        }

      
        public void Register(UserRegisterModel UserRegisterModel)
        {
            ValidateUser(UserRegisterModel);

            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(UserRegisterModel.Password));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            // netikazuvam123 -> dsfhai83473seidfsa893-495-233473awkkwsfdne

            // move this to a mapper method
            User newUser = new User
            {
                FirstName = UserRegisterModel.FirstName,
                LastName = UserRegisterModel.LastName,
                Username = UserRegisterModel.Username,
                Password = hashedPassword // we send the hashed password to the DB
            };
            _userRepository.Add(newUser);
        }

        private void ValidateUser(UserRegisterModel registerUserModel)
        {
            if (string.IsNullOrEmpty(registerUserModel.Username) || string.IsNullOrEmpty(registerUserModel.Password))
            {
                throw new UserException("Username and password are required fields");
            }
            if (registerUserModel.Username.Length > 30)
            {
                throw new UserException("Username can contain max 30 characters");
            }
            if (registerUserModel.FirstName.Length > 50 || registerUserModel.LastName.Length > 50)
            {
                throw new UserException("Firstname and Lastname can contain maximum 50 characters!");
            }
            if (!IsUserNameUnique(registerUserModel.Username))
            {
                throw new UserException("A user with this username already exists!");
            }
            if (registerUserModel.Password != registerUserModel.ConfirmPassword)
            {
                throw new UserException("The passwords do not match!");
            }
            if (!IsPasswordValid(registerUserModel.Password))
            {
                throw new UserException("The password is not complex enough!");
            }
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }

        private bool IsUserNameUnique(string username)
        {
            return _userRepository.GetUserByUsername(username) == null;
        }
    }
}

