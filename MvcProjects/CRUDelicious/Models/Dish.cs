#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;


public class Dish
{
    [Key]
    public int DishId {get; set;}

    [MinLength(2, ErrorMessage ="Name must be at least 2")]
    public string Name {get; set;}

    [MinLength(2, ErrorMessage ="Name must be at least 2")]
    public string Chef {get; set;}

    public int Tastiness {get; set;}
    public int Calories {get; set;}

    [MinLength(5, ErrorMessage = "Must be longer than 5")]
    public string? Description {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}