using Server.Infrastructure.Repository;
using Server.Infrastructure.Entities;
namespace Server.Application_.Services;

public class UserServices
{
    private readonly UserRepository _userRepo;

    public UserServices(UserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<List<User>> GetAllUsers(){ 
        return await _userRepo.GetAllUsers();
    }

     public async Task<User> GetByEmail(string email){ 
        return await _userRepo.GetByEmail(email);
    }

     public async Task<User> GetById(int id){ 
        return await _userRepo.GetById(id);
    }
      public async Task<bool> CreateUser(User user){ 
        return await _userRepo.AddNewUser(user);
    }
}
