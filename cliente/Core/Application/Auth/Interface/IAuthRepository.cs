using cliente.Core.Domain.Auth.DTO;
using cliente.Core.Domain.Auth.Entities;
using cliente.Core.Domain.Client.Entities;

namespace cliente.Core.Application.Auth.Interface
{
    public interface IAuthRepository
    {
        public Task<Account> GetUserAsync(AutenticateUserDTO login);
    }
}
