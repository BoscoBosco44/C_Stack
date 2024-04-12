#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndRegistration.Models;


public class User
{
    [Key]
    public int UserId {get; set;}

    [MinLength(2, ErrorMessage = "First name must be longer than 2")]
    public string FirstName {get; set;}

    [MinLength(2, ErrorMessage = "Last name must be longer than 2")]
    public string LastName {get; set;}

    [EmailAddress] //checks if email
    public string Email {get; set;}

    [DataType(DataType.Password)] //???
    [MinLength(5, ErrorMessage ="Password must be at least 5 char")]
    public string Password {get; set;}

    [NotMapped]
    [Compare("Password")] //build-in attribute for comparing two class feilds
    public string ConfirmPassword {get; set;}



    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

}