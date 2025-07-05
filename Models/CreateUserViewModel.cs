using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public List<string> AvailableRoles { get; set; } = [];
    }
}
