using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Data;

namespace ChatApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ChatDbContext _context;

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;
        
        return new UserDto
        {
            Id = user.Id,
            Nickname = user.Nickname
        };
    }

    public async Task<Guid> AddAsync(UserDto user)
    {
        var newUser = new User
        {
            Nickname = user.Nickname
        };
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}