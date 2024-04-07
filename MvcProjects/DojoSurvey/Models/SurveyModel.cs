#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models;
public class Survey
{
    [Required]
    [MinLength(2, ErrorMessage ="Name must be at least 2")]
    public string Name {get;set;}

    [Required]
    public string Location {get;set;}

    [Required]
    public string FavLang {get;set;}

    [MinLength(5, ErrorMessage = "Comment must be longer than 20 char")]
    public string? Comment {get;set;} = default!;
    
}

