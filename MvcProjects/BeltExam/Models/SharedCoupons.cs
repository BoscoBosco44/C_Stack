#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models;

public class SharedCoupon
{
    [Key]
    public int SharedCouponId {get; set;}

    public int UserId {get;set;}

    public int CouponId {get; set;}

    // public bool MarkedExpired {get; set;}


    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    public User? UserSharingCoupon {get;set;}
    public Coupon? CouponSharedByUser {get;set;}

}