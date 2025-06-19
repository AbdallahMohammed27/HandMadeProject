namespace HandMadeEcommece.Models.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Vendor>Vendors { get; set; } = new List<Vendor>();
        public ICollection<Admin> Admins { get; set; } = new List<Admin>();
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<ClaimRole> ClaimRoles { get; set; } = new List<ClaimRole>();
    }
}
