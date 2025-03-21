using Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models_;

namespace Server.Repositories;

public class UserRepository : IUserRepository
{
    private AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<User?> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
    }

}
