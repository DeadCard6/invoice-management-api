using InvoiceManagementApi.Domain.Entities;
using InvoiceManagementApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApi.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
}

