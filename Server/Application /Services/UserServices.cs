using Server.Application_.Interfaces;
using Server.Infrastructure.Entities;

namespace Server.Application_.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepo;

    //useless
    /*  private string HashPassword(string pass)
     {
         using (SHA256 hash = SHA256.Create())
         {
             byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
             StringBuilder res = new StringBuilder();
             foreach (byte s in data)
             {
                 res.Append(s.ToString("x2"));
             }
             return res.ToString();
         }
     } */

    public UserServices(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepo.GetAllUsers();
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRepo.GetByEmail(email);
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepo.GetById(id);
    }

    public async Task<bool> CreateUser(User user)
    {
        Console.WriteLine("User has arrived i nthe service layer");
        return await _userRepo.AddNewUser(user);
    }
}
