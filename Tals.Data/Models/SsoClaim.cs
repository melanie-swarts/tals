using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoClaim
{
    public int Id { get; set; }

    public string ClaimType { get; set; } = null!;

    public string ClaimValue { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? SsoRoleId { get; set; }

    public virtual SsoRole? SsoRole { get; set; }

    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
}
