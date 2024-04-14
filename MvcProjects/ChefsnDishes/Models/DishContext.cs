#pragma warning disable CS8618

using ChefsnDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsnDishes;


public class DishContext : DbContext
{
    public DishContext(DbContextOptions options) : base(options) { }

    public DbSet<Dish> Dishes {get; set;}
}