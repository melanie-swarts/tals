using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SsoClaim> SsoClaims { get; set; } = new List<SsoClaim>();
}
