using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoCompany
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<SsoUser> SsoUsers { get; set; } = new List<SsoUser>();
}
