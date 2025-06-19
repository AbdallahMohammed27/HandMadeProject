namespace HandMadeEcommece.Models.Data
{
    public class ClaimVendor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimValue { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimType { get; set; }
        public int VendorId { get; set; }
        public Vendor vendor { get; set; } = null!;
    }
}
