#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;


public class Chef 
{
    [Key]
    public int ChefId {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    public string LastName {get; set;}

    [Required(ErrorMessage = "put something here plz")]
    [Age18Check]
    public DateTime DOB {get; set;}

    //nav prop
    public List<Dish> ChefsDishes {get; set;} = new List<Dish>(); // track MANY dishes a chef has made

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;



    public int Age()
    {
        TimeSpan age = DateTime.Now - DOB;
        return age.Days/365;
    }


    public class AgeCheckAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        { 
            if (DateTime.Now < ((DateTime)value!))
            {
                return new ValidationResult("Please enter a day in the past");
            } else {
                return ValidationResult.Success;
            }
        }
    }
    public class Age18CheckAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        { 
            TimeSpan span = DateTime.Now - (DateTime)value;
            int years = span.Days / 365;
            if (years < 18)
            {
                return new ValidationResult("Must be older than 18");
            } else {
                return ValidationResult.Success;
            }
        }
    }




}