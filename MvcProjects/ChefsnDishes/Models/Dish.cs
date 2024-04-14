#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;


public class Dish
{
    [Key]
    public int DishId {get; set;}
    public string Name {get; set;}
    public int Calories {get; set;}
    public int Tastiness {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    //Navigation property:
    public Chef? Creator {get; set;}
}