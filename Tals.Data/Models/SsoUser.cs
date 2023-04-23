using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class SsoUser
{
    public int Id { get; set; }

    public Guid AspUserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Department { get; set; }

    public string? JobTitle { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public byte[]? ProfilePhoto { get; set; }

    public byte[]? SignatureImage { get; set; }

    public string? Directorate { get; set; }

    public int? SsoAddressId { get; set; }

    public string? BusinessPhone { get; set; }

    public int? SsoCompanyId { get; set; }

    public int? SsoJobTitleId { get; set; }

    public int? SsoDepartmentId { get; set; }

    public virtual AspNetUser AspUser { get; set; } = null!;

    public virtual ICollection<AuditHistory> AuditHistoryActionedByNavigations { get; set; } = new List<AuditHistory>();

    public virtual ICollection<AuditHistory> AuditHistoryUsers { get; set; } = new List<AuditHistory>();

    public virtual SsoAddress? SsoAddress { get; set; }

    public virtual SsoCompany? SsoCompany { get; set; }

    public virtual SsoDepartment? SsoDepartment { get; set; }

    public virtual SsoJobTitle? SsoJobTitle { get; set; }

    public virtual ICollection<SsoSystem> SsoSystems { get; set; } = new List<SsoSystem>();

    public virtual ICollection<SystemAdministrator> SystemAdministratorModifiedByNavigations { get; set; } = new List<SystemAdministrator>();

    public virtual ICollection<SystemAdministrator> SystemAdministratorUsers { get; set; } = new List<SystemAdministrator>();

    public virtual ICollection<SystemLibrary> SystemLibraries { get; set; } = new List<SystemLibrary>();

    public virtual ICollection<SystemRequest> SystemRequests { get; set; } = new List<SystemRequest>();

    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();

    public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
}
