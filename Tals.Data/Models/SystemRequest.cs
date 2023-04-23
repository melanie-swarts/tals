using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SystemRequest
{
    public int SsoSystemId { get; set; }

    public int SsoUserId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SsoSystem SsoSystem { get; set; } = null!;

    public virtual SsoUser SsoUser { get; set; } = null!;
}
