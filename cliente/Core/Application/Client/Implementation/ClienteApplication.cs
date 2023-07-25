using Azure;
using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Client.DTO;
using cliente.Core.Domain.Client.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cliente.Core.Application.Implementation
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(
            IClienteRepository clienteRepository
            )
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<PessoaEntity>> FindClients()
        {
            try
            {
                return await _clienteRepository.GetPessoasAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PessoaEntity> Save(ClienteSaveDTO saveDTO)
        {
            try
            {
                return await _clienteRepository.CreateClienteAsync(saveDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
