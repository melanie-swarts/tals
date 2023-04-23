using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class AuditRecord
{
    public int Id { get; set; }

    public int AuditHistoryId { get; set; }

    public string? FieldName { get; set; }

    public string? Before { get; set; }

    public string? After { get; set; }

    public virtual AuditHistory AuditHistory { get; set; } = null!;
}
