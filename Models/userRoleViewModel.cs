namespace InventorySystem.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        public List<string> AvailableRoles { get; set; } = [];
        public string SelectedRole { get; set; } = string.Empty;
    }


}
