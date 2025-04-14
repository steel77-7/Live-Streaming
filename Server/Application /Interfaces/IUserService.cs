using Server.Infrastructure.Entities;
namespace Server.Application_.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();
    public Task<bool> GetByEmailAndPassword(string email, string pass);
    public Task<User> GetById(int id);
    public Task<bool> CreateUser(User user);
}
