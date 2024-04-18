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
    public DateTime Date {get; set;}

    public string Address {get; set;}



    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    //forgin key
    public int UserId {get; set;}

    //nav props
    public User? PlannerUser {get; set;}
    public List<RSVP> RsvpedGuests {get; set;}
}