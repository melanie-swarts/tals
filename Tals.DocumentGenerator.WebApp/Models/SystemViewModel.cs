using System.ComponentModel.DataAnnotations;

namespace Tals.WebApp.Models
{
        public class SystemViewModel
        {
            public int SystemId { get; set; }

            [Required(ErrorMessage = "System name is required")]
            [RegularExpression("^[0-9A-Za-z ]+$", ErrorMessage = "Letters and numbers are only valid")]
            [MaxLength(50, ErrorMessage = "System name maximum length is 50")]
            public string Name { get; set; }

            [Required(ErrorMessage = "System description is required")]
            [RegularExpression("^[0-9A-Za-z ]+$", ErrorMessage = "Letters and numbers are only valid")]
            [MaxLength(140, ErrorMessage = "System description maximum length is 140")]
            public string Description { get; set; }

            public int AdministratorId { get; set; }

            [Required(ErrorMessage = "System url is required")]
            [MaxLength(512, ErrorMessage = "System url maximum length is 512")]
            public string? SystemUrl { get; set; }

            [Required(ErrorMessage = "Install url is required")]
            [MaxLength(512, ErrorMessage = "Install url maximum length is 512")]
            public string? InstallUrl { get; set; }

            [Required(ErrorMessage = "Security ID is required")]
            [RegularExpression("^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "Only valid GUIDs are allowed")]
            [MaxLength(50, ErrorMessage = "Security ID maximum length is 50")]
            public string? SecurityId { get; set; }

            [Required(ErrorMessage = "Audience ID is required")]
            [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", ErrorMessage = "Only valid URLs are allowed")]
            [MaxLength(100, ErrorMessage = "Audience ID maximum length is 100")]
            public string? AudienceId { get; set; }

            [MaxLength(25, ErrorMessage = "Public key maximum length is 25")]
            public string? PublicKey { get; set; }

            [MaxLength(25, ErrorMessage = "Private key maximum length is 25")]
            public string? PrivateKey { get; set; }

            public string? DisplayName { get; set; }

            public string? Administrator { get; set; }
            public string? AdministratorEmail { get; set; }
            public bool IsActive { get; set; }
            public string? LastLogin { get; set; }
            public int SystemRequestCount { get; set; }
            public int UserRequestCount { get; set; }
            public bool ShowCancelButton { get; set; }
            public bool ShowSystemOwnerOptions { get; set; }
            public bool ShowInstallButton { get; set; }
            public bool ShowLoginButton { get; set; }
            public bool ShowRequestButton { get; set; }
            public bool ShowSystemCard { get; set; }
            public string? SupportEmail { get; set; }
            public bool? AnnouncementEnabled { get; set; }
            public DateTime? AnnouncementStartDate { get; set; }
            public DateTime? AnnouncementEndDate { get; set; }
            public bool? BlockSystemLogin { get; set; }
            public string? AnnouncementMessage { get; set; }

        }
    }
