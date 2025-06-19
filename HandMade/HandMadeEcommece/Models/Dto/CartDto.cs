namespace HandMadeEcommece.Models.Dto
{
    public class CartDto
    {
        public int? UserId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int IsActived { get; set; }
    }
}
