#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;


public class Dish
{
    [Key]
    public int DishId {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    public string Name {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    [MinLength(1, ErrorMessage = "must be longer than 1")]
    public int Calories {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    public int Tastiness {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    //forgein key
    public int ChefId {get; set;}

    //Navigation property:
    public Chef? Creator {get; set;}
}