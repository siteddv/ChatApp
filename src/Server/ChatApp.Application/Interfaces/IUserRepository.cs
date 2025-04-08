using ChatApp.Application.Dtos;
using ChatApp.Domain.Entities;

namespace ChatApp.Application.Interfaces;

public interface IUserRepository
{
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(UserDto user);
}