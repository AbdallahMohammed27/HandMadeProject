using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class Chat
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int VendorId { get; set; }

    public string Message { get; set; } = null!;

    public int Seen { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public User User { get; set; } = null!;
    public Vendor Vendor { get; set; } = null!;
}
