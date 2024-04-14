#pragma warning disable CS8618

using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories;


public class TheContext : DbContext
{
    public TheContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Association> Associations {get; set;}
}