namespace HandMadeEcommece.Models.Dto
{
    public class OrderVendorDto
    {
        [Required]
        public int VendorId { get; set; }
        [Required]
        public int OrderId {  get; set; }
    }
}
