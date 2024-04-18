#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;

public class RSVP
{
    [Key]
    public int RsvpId {get; set;}


    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    //forgin key
    public int UserId {get;set;}
    public int WeddingId {get; set;}

    //nav props
    public User? RsvpingUser {get; set;}
    public Wedding? RsvpWedding {get; set;}


}