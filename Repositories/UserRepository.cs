using Microsoft.EntityFrameworkCore;
using Umuhinzi.Data;
using Umuhinzi.Models;

namespace Umuhinzi.Repositories;


public class UserRepository(AppDbContext db) : IUserRepository
{
    public Task<User?> GetByIdAsync(long id, CancellationToken ct = default) =>
        db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
}