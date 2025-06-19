namespace HandMadeEcommece.Models.Data
{
    public class ClaimAdmin
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimValue { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimType { get; set; }
        public int AdminId { get; set; }
        public Admin admin { get; set; } = null!;
    }
}
