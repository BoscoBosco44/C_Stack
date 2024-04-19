#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models;

public class Coupon
{
    [Key]
    public int CouponId {get; set;}

    public string CouponCode {get; set;}

    public string ApplicableWebsite {get; set;}

    [MinLength(10, ErrorMessage = "Description must be longer than 10 char")]
    public string Description {get; set;}


    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    //forgin key
    public int? UserId {get; set;}

    //nav props
    public User? CouponCreator {get; set;}
    public List<SharedCoupon> UsersWhoUsedThisCoupon {get; set;} = [];

}