using Server.Models_;
namespace Server.Repositories;

public interface IUserRepository
{
     Task<IEnumerable<User>> GetAllUsersAsync();
     Task<User> GetUserByIdAsync(int id); 
     Task<bool> DeleteUserAsync(int id); 
     Task<User> CreateUserAsync(User user);
      Task<User?> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
}
