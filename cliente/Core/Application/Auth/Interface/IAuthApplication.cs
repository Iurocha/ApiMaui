using cliente.Core.Domain.Auth.DTO;
using cliente.Core.Domain.Auth.Entities;

namespace cliente.Core.Application.Auth.Interface
{
    public interface IAuthApplication
    {
        public Task<dynamic> Login(AutenticateUserDTO user);
        public Task<dynamic> Register(RegistrationUserDTO user);
    }
}