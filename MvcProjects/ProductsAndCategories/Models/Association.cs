#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;


public class Association
{
    [Key]
    public int AssociationId {get; set;}

    //linking Ids
    public int ProductID {get; set;}

    public int CategoryId {get; set;}

    //nav props - DONT FORGET THE ?
    public Product? Product {get; set;}
    public Category? Category {get; set;}
}