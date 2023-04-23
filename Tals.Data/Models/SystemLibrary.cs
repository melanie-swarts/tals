using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SystemLibrary
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SsoSystemId { get; set; }

    public int UploaderId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual SsoSystem SsoSystem { get; set; } = null!;

    public virtual SsoUser Uploader { get; set; } = null!;
}
