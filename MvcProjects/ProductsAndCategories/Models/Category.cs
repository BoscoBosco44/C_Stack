#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCategories.Models;


public class Category
{
    [Key]
    public int CategorytId {get; set;}

    public string Name {get; set;}

    public List<Product> Products {get; set;} = new List<Product>();


    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}