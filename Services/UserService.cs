using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using authentication.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace authentication.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>()
        {
            new User() {Id = 1, Password = "tiger", Username = "user1"},
            new User() {Id = 2, Password = "lion", Username = "user2"},
            new User() {Id = 3, Password = "pig", Username = "user3"}
        };

        private readonly AuthSettings _authSettings;
        public UserService(IOptions<AuthSettings> appSettings) => _authSettings = appSettings.Value;
        
        /// <summary>
        /// Checking whether user exists in the database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _users.SingleOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}