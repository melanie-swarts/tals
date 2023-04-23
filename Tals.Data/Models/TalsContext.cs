using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tals.Data.Models;

public partial class TalsContext : DbContext
{
    public TalsContext()
    {
    }

    public TalsContext(DbContextOptions<TalsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<AuditHistory> AuditHistories { get; set; }

    public virtual DbSet<AuditRecord> AuditRecords { get; set; }

    public virtual DbSet<Laosuser> Laosusers { get; set; }

    public virtual DbSet<RoleClaim> RoleClaims { get; set; }

    public virtual DbSet<SsoAddress> SsoAddresses { get; set; }

    public virtual DbSet<SsoClaim> SsoClaims { get; set; }

    public virtual DbSet<SsoCompany> SsoCompanies { get; set; }

    public virtual DbSet<SsoDepartment> SsoDepartments { get; set; }

    public virtual DbSet<SsoJobTitle> SsoJobTitles { get; set; }

    public virtual DbSet<SsoRole> SsoRoles { get; set; }

    public virtual DbSet<SsoSystem> SsoSystems { get; set; }

    public virtual DbSet<SsoToken> SsoTokens { get; set; }

    public virtual DbSet<SsoUser> SsoUsers { get; set; }

    public virtual DbSet<SystemAdministrator> SystemAdministrators { get; set; }

    public virtual DbSet<SystemLibrary> SystemLibraries { get; set; }

    public virtual DbSet<SystemRequest> SystemRequests { get; set; }

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TALS;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.ToTable("AspNetRoles", "TALS");

            entity.HasIndex(e => e.Name, "IX_AspNetRoles_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.ToTable("AspNetUsers", "TALS");

            entity.HasIndex(e => e.UserName, "IX_AspNetUsers_UserName").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.ToTable("AspNetUserClaims", "TALS");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

            entity.ToTable("AspNetUserLogins", "TALS");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_UserId");
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.ToTable("AspNetUserRoles", "TALS");

            entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserRoles_UserId");

            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("IS_ACTIVE");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetUserRoles_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserRoles_UserId");
        });

        modelBuilder.Entity<AuditHistory>(entity =>
        {
            entity.ToTable("AUDIT_HISTORY", "TALS");

            entity.HasIndex(e => e.ActionedBy, "IX_AUDIT_HISTORY_ACTIONED_BY");

            entity.HasIndex(e => e.SystemId, "IX_AUDIT_HISTORY_SYSTEM_ID");

            entity.HasIndex(e => e.UserId, "IX_AUDIT_HISTORY_USER_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionDate).HasColumnName("ACTION_DATE");
            entity.Property(e => e.ActionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACTION_TYPE");
            entity.Property(e => e.ActionedBy).HasColumnName("ACTIONED_BY");
            entity.Property(e => e.SystemId).HasColumnName("SYSTEM_ID");
            entity.Property(e => e.TargetType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TARGET_TYPE");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.ActionedByNavigation).WithMany(p => p.AuditHistoryActionedByNavigations)
                .HasForeignKey(d => d.ActionedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIONED_BY");

            entity.HasOne(d => d.System).WithMany(p => p.AuditHistories)
                .HasForeignKey(d => d.SystemId)
                .HasConstraintName("FK_SYSTEM_ID");

            entity.HasOne(d => d.User).WithMany(p => p.AuditHistoryUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_USER_ID");
        });

        modelBuilder.Entity<AuditRecord>(entity =>
        {
            entity.ToTable("AUDIT_RECORDS", "TALS");

            entity.HasIndex(e => e.AuditHistoryId, "IX_AUDIT_HISTORY_RECORD_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.After)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("AFTER");
            entity.Property(e => e.AuditHistoryId).HasColumnName("AUDIT_HISTORY_ID");
            entity.Property(e => e.Before)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BEFORE");
            entity.Property(e => e.FieldName)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("FIELD_NAME");

            entity.HasOne(d => d.AuditHistory).WithMany(p => p.AuditRecords)
                .HasForeignKey(d => d.AuditHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUDIT_HISTORY_ID");
        });

        modelBuilder.Entity<Laosuser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LAOSUSERS", "TALS");

            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ROLE");
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROLE_CLAIM", "TALS");

            entity.HasIndex(e => e.SsoClaimId, "IX_ROLE_CLAIM_CLAIM_ID");

            entity.HasIndex(e => e.SsoRoleId, "IX_ROLE_CLAIM_ROLE_ID");

            entity.HasIndex(e => e.SsoSystemId, "IX_ROLE_CLAIM_SYSTEM_ID");

            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.SsoClaimId).HasColumnName("SSO_CLAIM_ID");
            entity.Property(e => e.SsoRoleId).HasColumnName("SSO_ROLE_ID");
            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");

            entity.HasOne(d => d.SsoClaim).WithMany()
                .HasForeignKey(d => d.SsoClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_CLAIM_CLAIM_ID");

            entity.HasOne(d => d.SsoRole).WithMany()
                .HasForeignKey(d => d.SsoRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_CLAIM_ROLE_ID");

            entity.HasOne(d => d.SsoSystem).WithMany()
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_CLAIM_SYSTEM_ID");
        });

        modelBuilder.Entity<SsoAddress>(entity =>
        {
            entity.ToTable("SSO_ADDRESS", "TALS");

            entity.HasIndex(e => e.Description, "UK_SSO_ADDRESS").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<SsoClaim>(entity =>
        {
            entity.ToTable("SSO_CLAIM", "TALS");

            entity.HasIndex(e => new { e.ClaimType, e.ClaimValue }, "IXU_CLAIM_TYPE_WITH_VALUE").IsUnique();

            entity.HasIndex(e => e.SsoRoleId, "IX_SSO_CLAIM_ROLE_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClaimType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLAIM_TYPE");
            entity.Property(e => e.ClaimValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLAIM_VALUE");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.SsoRoleId).HasColumnName("SSO_ROLE_ID");

            entity.HasOne(d => d.SsoRole).WithMany(p => p.SsoClaims)
                .HasForeignKey(d => d.SsoRoleId)
                .HasConstraintName("FK_SSO_CLAIM_ROLE_ID");
        });

        modelBuilder.Entity<SsoCompany>(entity =>
        {
            entity.ToTable("SSO_COMPANY", "TALS");

            entity.HasIndex(e => e.Description, "UK_SSO_COMPANY").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<SsoDepartment>(entity =>
        {
            entity.ToTable("SSO_DEPARTMENT", "TALS");

            entity.HasIndex(e => e.Description, "UK_SSO_DEPARTMENT").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<SsoJobTitle>(entity =>
        {
            entity.ToTable("SSO_JOB_TITLE", "TALS");

            entity.HasIndex(e => e.Description, "UK_SSO_JOB_TITLE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("(CONVERT([bit],(1)))")
                .HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<SsoRole>(entity =>
        {
            entity.ToTable("SSO_ROLE", "TALS");

            entity.HasIndex(e => e.Name, "IXU_ROLE_NAME").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<SsoSystem>(entity =>
        {
            entity.ToTable("SSO_SYSTEM", "TALS");

            entity.HasIndex(e => e.Name, "IXU_SYSTEM_NAME").IsUnique();

            entity.HasIndex(e => e.AdministratorId, "IX_SYSTEM_ADMINISTRATOR_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdministratorId).HasColumnName("ADMINISTRATOR_ID");
            entity.Property(e => e.AnnouncementEndDate).HasColumnName("ANNOUNCEMENT_END_DATE");
            entity.Property(e => e.AnnouncementStartDate).HasColumnName("ANNOUNCEMENT_START_DATE");
            entity.Property(e => e.AnnouncementsEnabled).HasColumnName("ANNOUNCEMENTS_ENABLED");
            entity.Property(e => e.AudienceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AUDIENCE_ID");
            entity.Property(e => e.BlockSystemLogin).HasColumnName("BLOCK_SYSTEM_LOGIN");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.Description)
                .HasMaxLength(140)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DISPLAY_NAME");
            entity.Property(e => e.InstallUrl)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("INSTALL_URL");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.PrivateKey)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PRIVATE_KEY");
            entity.Property(e => e.PublicKey)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PUBLIC_KEY");
            entity.Property(e => e.SecurityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SECURITY_ID");
            entity.Property(e => e.SystemAnnouncementMessage)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("SYSTEM_ANNOUNCEMENT_MESSAGE");
            entity.Property(e => e.SystemUrl)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("SYSTEM_URL");

            entity.HasOne(d => d.Administrator).WithMany(p => p.SsoSystems)
                .HasForeignKey(d => d.AdministratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_ADMINISTRATOR_ID");
        });

        modelBuilder.Entity<SsoToken>(entity =>
        {
            entity.ToTable("SSO_TOKEN", "TALS");

            entity.HasIndex(e => e.AspUserId, "IX_SSO_TOKEN_ASP_USER_ID");

            entity.HasIndex(e => e.CreatedAt, "IX_SSO_TOKEN_CREATED_AT");

            entity.HasIndex(e => e.SsoSystemId, "IX_SSO_TOKEN_SYSTEM_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AspUserId).HasColumnName("ASP_USER_ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");
            entity.Property(e => e.TokenSecret)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TOKEN_SECRET");

            entity.HasOne(d => d.AspUser).WithMany(p => p.SsoTokens)
                .HasForeignKey(d => d.AspUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SSO_TOKEN_ASP_USER_ID");

            entity.HasOne(d => d.SsoSystem).WithMany(p => p.SsoTokens)
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SSO_TOKEN_SYSTEM_ID");
        });

        modelBuilder.Entity<SsoUser>(entity =>
        {
            entity.ToTable("SSO_USER", "TALS");

            entity.HasIndex(e => e.SsoAddressId, "IX_SSO_USER_ADDRESS_ID");

            entity.HasIndex(e => e.SsoCompanyId, "IX_SSO_USER_COMPANY_ID");

            entity.HasIndex(e => e.SsoDepartmentId, "IX_SSO_USER_DEPARTMENT_ID");

            entity.HasIndex(e => e.SsoJobTitleId, "IX_SSO_USER_JOB_TITLE_ID");

            entity.HasIndex(e => e.AspUserId, "IX_USER_ASP_USER_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AspUserId).HasColumnName("ASP_USER_ID");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BUSINESS_PHONE");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Directorate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECTORATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("JOB_TITLE");
            entity.Property(e => e.LastLogin).HasColumnName("LAST_LOGIN");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.ProfilePhoto).HasColumnName("PROFILE_PHOTO");
            entity.Property(e => e.SignatureImage).HasColumnName("SIGNATURE_IMAGE");
            entity.Property(e => e.SsoAddressId).HasColumnName("SSO_ADDRESS_ID");
            entity.Property(e => e.SsoCompanyId).HasColumnName("SSO_COMPANY_ID");
            entity.Property(e => e.SsoDepartmentId).HasColumnName("SSO_DEPARTMENT_ID");
            entity.Property(e => e.SsoJobTitleId).HasColumnName("SSO_JOB_TITLE_ID");

            entity.HasOne(d => d.AspUser).WithMany(p => p.SsoUsers)
                .HasForeignKey(d => d.AspUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ASP_USER_ID");

            entity.HasOne(d => d.SsoAddress).WithMany(p => p.SsoUsers)
                .HasForeignKey(d => d.SsoAddressId)
                .HasConstraintName("FK_SSO_USER_ADDRESS_ID");

            entity.HasOne(d => d.SsoCompany).WithMany(p => p.SsoUsers)
                .HasForeignKey(d => d.SsoCompanyId)
                .HasConstraintName("FK_SSO_USER_COMPANY_ID");

            entity.HasOne(d => d.SsoDepartment).WithMany(p => p.SsoUsers)
                .HasForeignKey(d => d.SsoDepartmentId)
                .HasConstraintName("FK_SSO_USER_DEPARTMENT_ID");

            entity.HasOne(d => d.SsoJobTitle).WithMany(p => p.SsoUsers)
                .HasForeignKey(d => d.SsoJobTitleId)
                .HasConstraintName("FK_SSO_USER_JOB_TITLE_ID");
        });

        modelBuilder.Entity<SystemAdministrator>(entity =>
        {
            entity.ToTable("SYSTEM_ADMINISTRATOR", "TALS");

            entity.HasIndex(e => e.ModifiedBy, "IX_SYSTEM_ADMINISTRATOR_MODIFIED_BY");

            entity.HasIndex(e => e.Systemid, "IX_SYSTEM_ADMINISTRATOR_SYSTEMID");

            entity.HasIndex(e => e.UserId, "IX_SYSTEM_ADMIN_USER_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.ModifiedBy).HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate).HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.RecievesEmail).HasColumnName("RECIEVES_EMAIL");
            entity.Property(e => e.Systemid).HasColumnName("SYSTEMID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.SystemAdministratorModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ADMIN_SSO_USER_ADMIN_ID_FK");

            entity.HasOne(d => d.System).WithMany(p => p.SystemAdministrators)
                .HasForeignKey(d => d.Systemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYSTEM_ADMIN_SSO_SYSTEM_ID_FK");

            entity.HasOne(d => d.User).WithMany(p => p.SystemAdministratorUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYSTEM_ADMIN_SSO_USER_ID_FK");
        });

        modelBuilder.Entity<SystemLibrary>(entity =>
        {
            entity.ToTable("SYSTEM_LIBRARY", "TALS");

            entity.HasIndex(e => e.Name, "IXU_SYSTEM_LIBRARY_NAME").IsUnique();

            entity.HasIndex(e => e.SsoSystemId, "IX_SYSTEM_LIBRARY_SSO_SYSTEM_ID");

            entity.HasIndex(e => e.UploaderId, "IX_SYSTEM_LIBRARY_UPLOADER_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");
            entity.Property(e => e.UploaderId).HasColumnName("UPLOADER_ID");

            entity.HasOne(d => d.SsoSystem).WithMany(p => p.SystemLibraries)
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_LIBRARY_SYSTEM_ID");

            entity.HasOne(d => d.Uploader).WithMany(p => p.SystemLibraries)
                .HasForeignKey(d => d.UploaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_LIBRARY_UPLOADER_ID");
        });

        modelBuilder.Entity<SystemRequest>(entity =>
        {
            entity.HasKey(e => new { e.SsoSystemId, e.SsoUserId });

            entity.ToTable("SYSTEM_REQUEST", "TALS");

            entity.HasIndex(e => e.SsoSystemId, "IX_SYSTEM_REQUEST_SYSTEM_ID");

            entity.HasIndex(e => e.SsoUserId, "IX_SYSTEM_REQUEST_USER_ID");

            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");
            entity.Property(e => e.SsoUserId).HasColumnName("SSO_USER_ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

            entity.HasOne(d => d.SsoSystem).WithMany(p => p.SystemRequests)
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_REQUEST_SYSTEM_ID");

            entity.HasOne(d => d.SsoUser).WithMany(p => p.SystemRequests)
                .HasForeignKey(d => d.SsoUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_REQUEST_USER_ID");
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => new { e.SsoSystemId, e.SsoUserId });

            entity.ToTable("SYSTEM_USER", "TALS");

            entity.HasIndex(e => e.SsoSystemId, "IX_SYSTEM_USER_SYSTEM_ID");

            entity.HasIndex(e => e.SsoUserId, "IX_SYSTEM_USER_USER_ID");

            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");
            entity.Property(e => e.SsoUserId).HasColumnName("SSO_USER_ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LastLogin).HasColumnName("LAST_LOGIN");

            entity.HasOne(d => d.SsoSystem).WithMany(p => p.SystemUsers)
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_USER_SYSTEM_ID");

            entity.HasOne(d => d.SsoUser).WithMany(p => p.SystemUsers)
                .HasForeignKey(d => d.SsoUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SYSTEM_USER_USER_ID");
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.HasKey(e => new { e.SsoSystemId, e.SsoUserId, e.SsoClaimId });

            entity.ToTable("USER_CLAIM", "TALS");

            entity.HasIndex(e => e.SsoClaimId, "IX_USER_CLAIM_CLAIM_ID");

            entity.HasIndex(e => e.SsoSystemId, "IX_USER_CLAIM_SYSTEM_ID");

            entity.HasIndex(e => e.SsoUserId, "IX_USER_CLAIM_USER_ID");

            entity.Property(e => e.SsoSystemId).HasColumnName("SSO_SYSTEM_ID");
            entity.Property(e => e.SsoUserId).HasColumnName("SSO_USER_ID");
            entity.Property(e => e.SsoClaimId).HasColumnName("SSO_CLAIM_ID");
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.SsoRoleId).HasColumnName("SSO_ROLE_ID");

            entity.HasOne(d => d.SsoClaim).WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.SsoClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_CLAIM_CLAIM_ID");

            entity.HasOne(d => d.SsoSystem).WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.SsoSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_CLAIM_SYSTEM_ID");

            entity.HasOne(d => d.SsoUser).WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.SsoUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_CLAIM_USER_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
