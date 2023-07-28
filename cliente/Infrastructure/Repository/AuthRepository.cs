using cliente.Core.Application.Auth.Interface;
using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Auth.DTO;
using cliente.Core.Domain.Auth.Entities;
using cliente.Core.Domain.Client.Entities;
using cliente.Infrastructure.EntityFrameworkCore.Context;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

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

    public async Task<bool> RegisterAccount(RegistrationUserDTO user)
    {
        string insertQuery = "INSERT INTO [Account]  VALUES (@Id, @FirstName, @LastName, @Gender, @UserName, @Password, @Role)";

        var Id = Guid.NewGuid().ToString();

        using (var connection = _context.CreateConnection())
        {
            connection.Execute(insertQuery, new { Id, user.FirstName, user.LastName, user.Gender, user.UserName, user.Password, user.Role });
        }

        return true;
    }
}