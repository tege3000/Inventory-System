using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using InventorySystem.Data;
using InventorySystem.Models;

namespace InventorySystem.Services
{
    public class AuditService
    {
        private readonly InventoryDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditService(InventoryDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _httpContextAccessor = accessor;
        }

        public async Task LogAction(string action)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = user?.FindFirstValue(ClaimTypes.Email) ?? "";
            var ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "";

            var log = new AuditLog
            {
                UserId = userId,
                UserEmail = email,
                Action = action,
                IPAddress = ip
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
