using Microsoft.EntityFrameworkCore;
using Server.Infrastructure.Data;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Repository;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var res = await _context.Users.ToListAsync();
        return res;
    }

    //to find something with an identifier ....email or username

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> AddNewUser(User user)
    {
       // return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
       await _context.Users.AddAsync(user);
       return true;
    }
}
