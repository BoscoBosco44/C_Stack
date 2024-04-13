#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;


public class Chef 
{
    [Required(ErrorMessage = "put something here plz")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    public string LastName {get; set;}
    
    [Required(ErrorMessage = "put something here plz")]
    public string DOB {get; set;}

}