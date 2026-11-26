using Umuhinzi.Models;

namespace Umuhinzi.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long id, CancellationToken ct = default);
}