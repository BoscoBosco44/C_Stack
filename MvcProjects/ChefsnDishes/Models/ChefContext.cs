#pragma warning disable CS8618

using ChefsnDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsnDishes;


public class ChefContext : DbContext
{
    public ChefContext(DbContextOptions options) : base(options) { }

    public DbSet<Chef> Chefs {get; set;}

    public DbSet<Dish> Dishes {get;set;}

    
}