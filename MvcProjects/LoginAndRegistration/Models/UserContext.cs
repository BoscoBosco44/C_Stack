#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace LoginAndRegistration.Models;


public class UserContext : DbContext
{
    public UserContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users {get; set;}
}