#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;


public class Product
{
    [Key]
    public int ProductId {get; set;}

    public string Name {get; set;}

    public double Price {get; set;}

    public string Description {get; set;}

    public List<Category> Categories {get; set;} = new List<Category>();

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}