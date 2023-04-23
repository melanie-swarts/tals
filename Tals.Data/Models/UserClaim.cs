using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class UserClaim
{
    public int SsoSystemId { get; set; }

    public int SsoUserId { get; set; }

    public int SsoClaimId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? SsoRoleId { get; set; }

    public virtual SsoClaim SsoClaim { get; set; } = null!;

    public virtual SsoSystem SsoSystem { get; set; } = null!;

    public virtual SsoUser SsoUser { get; set; } = null!;
}
