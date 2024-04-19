#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;

public class Wedding
{  
    [Key]
    public int WeddingId {get; set;}

    public string WedderOne {get; set;}

    public string WedderTwo {get; set;}

    [DataType(DataType.Date)]
    [FutureDateCheck]
    public DateTime Date {get; set;}

    public string Address {get; set;}



    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    //forgin key
    public int? UserId {get; set;}

    //nav props
    public User? PlannerUser {get; set;}
    public List<RSVP> RsvpedGuests {get; set;} = [];






    //Custom Validatoin
    public class FutureDateCheckAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        { 
            TimeSpan span = DateTime.Now - (DateTime)value;
            if (DateTime.Now > (DateTime)value)
            {
                return new ValidationResult("Date must be in the future");
            } else {
                return ValidationResult.Success;
            }
        }
    }
}