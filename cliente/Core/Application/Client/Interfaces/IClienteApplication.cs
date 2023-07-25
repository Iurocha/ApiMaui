using cliente.Core.Domain.Client.DTO;
using cliente.Core.Domain.Client.Entities;

namespace cliente.Core.Application.Interfaces
{
    public interface IClienteApplication
    {
        public Task<IEnumerable<PessoaEntity>> FindClients();
        public Task<PessoaEntity> Save(ClienteSaveDTO clienteSave);
    }
}
