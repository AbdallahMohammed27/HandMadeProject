namespace HandMadeEcommece.Models.Dto
{
    public class WishListDto
    {
        [Required]
        public int UserId {  get; set; }
        [Required]
        public int ProductId {  get; set; }
    }
}
