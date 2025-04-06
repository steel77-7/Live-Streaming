using Microsoft.EntityFrameworkCore;
using Server.Application_.Interfaces;
using Server.Infrastructure.Data;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Repository;

public class UserRepository : IUserRepository
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
        Console.WriteLine(email);

        User res = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (res == null)
        {
            Console.WriteLine("not found");
            return res;
        }
        Console.WriteLine("in the login : " + res.Id);
        return res;
    }

    public async Task<User> GetById(int id)
    {
        var res = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return res;
    }

    public async Task<bool> AddNewUser(User user)
    {
        // return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        Console.WriteLine("User has arrived in the repo layer");
        var res = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        Console.WriteLine("the res :" + res);
        return true;
    }
}
