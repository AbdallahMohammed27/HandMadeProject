using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data
{
    public class DeliveryCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Delivery_Zones { get; set; } = null!;
        public decimal Pricing {  get; set; }
        public string IdTax { get; set; } = null!;
        [Column(TypeName = "VARCHAR(255)")]
        public string Logo { get; set; } = null!;
        public ICollection<Order> orders { get; set; } = new List<Order>();
        public ICollection<TransactionMoney>transactionMoneys { get; set; } = new List<TransactionMoney>();
        public ICollection<PaypalSetting> paypalSetting { get; set; } = new List<PaypalSetting>();
    }
}
