using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoSystem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int AdministratorId { get; set; }

    public string SystemUrl { get; set; } = null!;

    public string SecurityId { get; set; } = null!;

    public string AudienceId { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? PublicKey { get; set; }

    public string? PrivateKey { get; set; }

    public string? InstallUrl { get; set; }

    public bool? AnnouncementsEnabled { get; set; }

    public DateTime? AnnouncementStartDate { get; set; }

    public DateTime? AnnouncementEndDate { get; set; }

    public bool? BlockSystemLogin { get; set; }

    public string? SystemAnnouncementMessage { get; set; }

    public string? DisplayName { get; set; }

    public virtual SsoUser Administrator { get; set; } = null!;

    public virtual ICollection<AuditHistory> AuditHistories { get; set; } = new List<AuditHistory>();

    public virtual ICollection<SsoToken> SsoTokens { get; set; } = new List<SsoToken>();

    public virtual ICollection<SystemAdministrator> SystemAdministrators { get; set; } = new List<SystemAdministrator>();

    public virtual ICollection<SystemLibrary> SystemLibraries { get; set; } = new List<SystemLibrary>();

    public virtual ICollection<SystemRequest> SystemRequests { get; set; } = new List<SystemRequest>();

    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();

    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
}
