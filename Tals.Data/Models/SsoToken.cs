using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoToken
{
    public int Id { get; set; }

    public int SsoSystemId { get; set; }

    public Guid AspUserId { get; set; }

    public string TokenSecret { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual AspNetUser AspUser { get; set; } = null!;

    public virtual SsoSystem SsoSystem { get; set; } = null!;
}
