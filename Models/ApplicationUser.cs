using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        public string RoleTitle { get; set; } = string.Empty;  // e.g. "Admin", "Staff", "Viewer"

        public bool IsActive { get; set; } = true;
  
    }
}