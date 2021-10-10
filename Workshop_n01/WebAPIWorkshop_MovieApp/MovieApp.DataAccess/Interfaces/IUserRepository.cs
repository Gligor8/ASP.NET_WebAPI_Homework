using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string password);
    }
}
