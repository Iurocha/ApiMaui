using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Client.DTO;
using cliente.Core.Domain.Client.Entities;
using cliente.Infrastructure.EntityFrameworkCore.Context;
using Dapper;
using System.Data;
using System.Runtime.ConstrainedExecution;

public class ClienteRepository : IClienteRepository
{
    private readonly ClienteContext _context;
    public ClienteRepository(ClienteContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PessoaEntity>> GetPessoasAsync()
    {
        var query = "SELECT * FROM Pessoa";
        using (var connection = _context.CreateConnection())
        {
            var companies = await connection.QueryAsync<PessoaEntity>(query);
            return companies.ToList();
        }
    }
    public async Task<PessoaEntity> CreateClienteAsync(ClienteSaveDTO company)
    {
        try
        {
            var query = "INSERT INTO Pessoa VALUES (@Nome, @CPF, @Telefone, @Email, @CEP)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("@Nome", company.Nome, DbType.String);
            parameters.Add("CPF", company.CPF, DbType.String);
            parameters.Add("Telefone", company.Telefone, DbType.String);
            parameters.Add("Email", company.Email, DbType.String);
            parameters.Add("CEP", company.CEP, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdCompany = new PessoaEntity
                {
                    Id = id,
                    Nome = company.Nome,
                    CPF = company.CPF,
                    Telefone = company.Telefone,
                    Email = company.Email,
                    CEP = company.CEP
                };

                return createdCompany;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }
}