using System.Threading.Tasks;

namespace TimPortfolioApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}