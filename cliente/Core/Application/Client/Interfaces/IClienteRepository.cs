using cliente.Core.Domain.Client.DTO;
using cliente.Core.Domain.Client.Entities;

namespace cliente.Core.Application.Interfaces
{
    public interface IClienteRepository
    {
        public Task<IEnumerable<PessoaEntity>> GetPessoasAsync();

        public Task<PessoaEntity> CreateClienteAsync(ClienteSaveDTO company);
    }
}
