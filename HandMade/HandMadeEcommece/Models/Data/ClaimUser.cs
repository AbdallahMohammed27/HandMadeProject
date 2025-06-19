namespace HandMadeEcommece.Models.Data
{
    public class ClaimUser
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimValue { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimType { get; set; }
        public int UserId { get; set; }
        public User user { get; set; } = null!;
    }
}
