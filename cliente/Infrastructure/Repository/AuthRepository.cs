using cliente.Core.Application.Auth.Interface;
using cliente.Core.Domain.Auth.DTO;
using cliente.Core.Domain.Auth.Entities;
using cliente.Core.Domain.Client.Entities;
using cliente.Infrastructure.EntityFrameworkCore.Context;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class AuthRepository : IAuthRepository
{
    private readonly ClienteContext _context;
    public AuthRepository(ClienteContext context)
    {
        _context = context;
    }

    public async Task<Account> GetUserAsync(AutenticateUserDTO login)
    {
        try
        {
            string query = "Select * from [Account] where [UserName] = @Username and [Password] = @Password";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryFirstAsync<Account>(query, new { login.Username, login.Password });
            
                return companies;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}