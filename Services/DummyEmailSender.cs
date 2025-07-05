using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"[DummyEmailSender] Email to {email} | Subject: {subject}");
            return Task.CompletedTask;
        }
    }
}
