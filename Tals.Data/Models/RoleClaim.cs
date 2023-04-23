using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class RoleClaim
{
    public int SsoSystemId { get; set; }

    public int SsoRoleId { get; set; }

    public int SsoClaimId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SsoClaim SsoClaim { get; set; } = null!;

    public virtual SsoRole SsoRole { get; set; } = null!;

    public virtual SsoSystem SsoSystem { get; set; } = null!;
}
