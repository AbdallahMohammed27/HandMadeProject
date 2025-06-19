namespace HandMadeEcommece.Models.Dto
{
    public class PusherSettingDto
    {
        [Required]
        public string PusherAppId { get; set; } = null!;
        [Required]

        public string PusherKey { get; set; } = null!;
        [Required]

        public string PusherSecret { get; set; } = null!;
        [Required]

        public string PusherCluster { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
