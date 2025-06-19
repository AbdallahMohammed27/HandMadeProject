namespace HandMadeEcommece.Models.Data
{
    public class AdminAddress
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; } = null!;

        public int State { get; set; }

        public string City { get; set; } = null!;

        public string Zip { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int AdminId {  get; set; }

        public Admin Admin { get; set; } = null!;
    }
}
