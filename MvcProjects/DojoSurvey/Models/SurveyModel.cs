#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models;


    public class LongerThan20Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null && ((string)value).Length < 20)
        {
            return new ValidationResult("Comment must be longer than 20");
        } else {
            return ValidationResult.Success;
        }
    }
}




public class Survey
{
    [MinLength(20, ErrorMessage = "Must be longer than 20")]
    public string? Comment {get;set;}
    
    [Required]
    [MinLength(2, ErrorMessage ="Name must be at least 2")]
    public string Name {get;set;}

    [Required]
    public string Location {get;set;}

    [Required]
    public string FavLang {get;set;}

    // [MinLength(5, ErrorMessage = "Comment must be longer than 20 char")]
    // [LongerThan20]



    // public class LongerThan20Attribute : ValidationAttribute
    // {
    //     protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    //     {
    //         if(value == null)
    //             return ValidationResult.Success;
    //         else if(((string)value).Length > 0 && ((string)value).Length < 20) 
    //             return new ValidationResult("Comment must be longer than 20 char");
    //         else
    //             return ValidationResult.Success;
    //     }
    // }


}

