using MyAppWithAngular.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppWithAngular.Data.Authentication
{
    public interface IAuthenticationRepository
    {
        public Task<User> RegisterNewUser(string userName, string password);

        public Task<User> Login(string userName, string password);

        public Task<bool> UserExists(string userName);
    }
}
