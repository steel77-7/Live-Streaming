using System;
using Microsoft.EntityFrameworkCore;
namespace Server.Entities;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; } = null;
}





