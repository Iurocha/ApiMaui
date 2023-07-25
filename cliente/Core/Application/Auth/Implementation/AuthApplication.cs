using cliente.Core.Application.Auth.Interface;
using cliente.Core.Domain.Auth.Entities;
using Microsoft.IdentityModel.Tokens;
using static Dapper.SqlMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cliente.Core.Domain.Auth.DTO;
using Microsoft.AspNetCore.Mvc;
using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Client.Entities;
using System.Reflection;

namespace cliente.Core.Application.Auth.Implementation
{
    public class AuthApplication : IAuthApplication
    {

        private readonly IAuthRepository _authRepository;

        public AuthApplication(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<dynamic> Login(AutenticateUserDTO login)
        {
            var user = await _authRepository.GetUserAsync(login);

            if (user == null)
                return new
                {
                    teste = "not found"
                };

            var token = GenerateToken(user);

            return new
            {
                token
            };
        }

        public static string GenerateToken(Account user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public Task<dynamic> Register(RegistrationUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
