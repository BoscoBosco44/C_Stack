#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;


public class ChefsnDishes
{
    public string Name {get; set;}
    public int Calories {get; set;}
    public Chef ChefName {get; set;}
    public int Tastiness {get; set;}
}