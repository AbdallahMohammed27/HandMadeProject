namespace HandMadeEcommece.Models.Dto
{
    public class UserCouponsDto
    {
        [Required]
        public int UserId {  get; set; }
        [Required]
        public int CouponId { get; set; }   
    }
}
