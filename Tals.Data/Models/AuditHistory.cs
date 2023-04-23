using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class AuditHistory
{
    public int Id { get; set; }

    public int ActionedBy { get; set; }

    public string? TargetType { get; set; }

    public int? SystemId { get; set; }

    public int? UserId { get; set; }

    public string ActionType { get; set; } = null!;

    public DateTime ActionDate { get; set; }

    public virtual SsoUser ActionedByNavigation { get; set; } = null!;

    public virtual ICollection<AuditRecord> AuditRecords { get; set; } = new List<AuditRecord>();

    public virtual SsoSystem? System { get; set; }

    public virtual SsoUser? User { get; set; }
}
