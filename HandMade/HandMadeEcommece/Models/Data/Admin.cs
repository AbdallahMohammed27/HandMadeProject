using HandMadeEcommece.helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml;

namespace HandMadeEcommece.Models.Data
{
    public class Admin
    {
        public int Id { get; set; }
        public int RoleId {  get; set; }
        [Column(TypeName = "VARCHAR(255)")]
        public string? Image { get; set; }
        public string Address { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<ClaimAdmin> claims { get; set; } = new List<ClaimAdmin>();
        public ICollection<Brand> brands { get; set; } = new List<Brand>();
        public ICollection<AdminBrand> adminBrands { get; set; } = new List<AdminBrand>();
        public ICollection<Category> categories { get; set; } = new List<Category>();
        public ICollection<AdminCategory>adminCategories { get; set; } = new List<AdminCategory>();
        public ICollection<AdminOrder> adminsOrders { get; set; } = new List<AdminOrder>();
        public ICollection<Order> orders { get; set; } = new List<Order>();
        public ICollection<Product> products { get; set; } = new List<Product>();
        public ICollection<AdminProduct> adminProducts { get; set; } = new List<AdminProduct>();
        public ICollection<AdminTransaction> adminTransactions { get; set; } = new List<AdminTransaction>();
        public ICollection<TransactionMoney> transactionMoneys { get; set; } = new List<TransactionMoney>();
        public ICollection<Vendor> vendors { get; set; } = new List<Vendor>();
        public ICollection<AdminVendor> adminVendors { get; set;} = new List<AdminVendor>();
        public ICollection<AdminVendorConditions> adminVendorConditions { get; set; } = new List<AdminVendorConditions>();
        public ICollection<VendorCondition>vendorConditions { get; set; } = new List<VendorCondition>();    
    }
}
