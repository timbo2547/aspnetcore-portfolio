using System.Threading.Tasks;

namespace TimPortfolioApp.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}