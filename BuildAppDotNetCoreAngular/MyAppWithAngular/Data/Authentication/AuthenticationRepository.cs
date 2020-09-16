using Microsoft.EntityFrameworkCore;
using MyAppWithAngular.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyAppWithAngular.Data.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private DatabaseContext _dbContext;

        public AuthenticationRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }


        #region IAuthenticationRepository
        public async Task<User> Login(string userName, string password)
        {
            User user = await _dbContext.Users.Where(dbUser => dbUser.UserName == userName).FirstOrDefaultAsync();

            if (user == null || !VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash)) return null;

            return user;
        }

        public async Task<User> RegisterNewUser(string userName, string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            this.CreateHashPassword(password: password, passwordSalt: out passwordSalt, passwordHash: out passwordHash);

            User user = new User()
            {
                UserName = userName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _dbContext.Users.Where(dbUser => dbUser.UserName == userName).AnyAsync();
        }

        #endregion IAuthenticationRepository

        #region Private Methods
        private void CreateHashPassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                hmac.Clear();
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            bool samePassword;

            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                byte[] informedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                samePassword = passwordHash.SequenceEqual(informedPassword);
                hmac.Clear();
            }

            return samePassword;
        }

        #endregion Private Methods
    }
}
