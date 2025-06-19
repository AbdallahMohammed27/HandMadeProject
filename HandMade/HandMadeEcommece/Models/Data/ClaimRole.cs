namespace HandMadeEcommece.Models.Data
{
    public class ClaimRole
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimValue { get; set; }
        [MaxLength(255), DataType("VARCHAR")]
        public string ClaimType { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
