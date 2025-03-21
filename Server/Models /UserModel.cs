using System;
using Microsoft.EntityFrameworkCore;
//using Server.Models_;
namespace Server.Models_;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; } = null;
}
