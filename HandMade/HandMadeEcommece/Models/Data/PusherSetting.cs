using System;
using System.Collections.Generic;

namespace HandMadeEcommece.Models.Data;

public class PusherSetting
{
    public int Id { get; set; }

    public string PusherAppId { get; set; } = null!;

    public string PusherKey { get; set; } = null!;

    public string PusherSecret { get; set; } = null!;

    public string PusherCluster { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
