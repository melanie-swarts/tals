using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SystemAdministrator
{
    public int Id { get; set; }

    public int Systemid { get; set; }

    public int UserId { get; set; }

    public bool RecievesEmail { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual SsoUser ModifiedByNavigation { get; set; } = null!;

    public virtual SsoSystem System { get; set; } = null!;

    public virtual SsoUser User { get; set; } = null!;
}
