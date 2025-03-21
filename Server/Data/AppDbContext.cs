using Microsoft.EntityFrameworkCore;
using Server.Models_;
namespace Server.Data;

public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }

}
