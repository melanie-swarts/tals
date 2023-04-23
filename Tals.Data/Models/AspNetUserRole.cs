using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class AspNetUserRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual AspNetRole Role { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
