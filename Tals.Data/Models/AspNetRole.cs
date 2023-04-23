using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class AspNetRole
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; } = new List<AspNetUserRole>();
}
