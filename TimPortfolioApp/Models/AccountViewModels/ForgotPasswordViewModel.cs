using System.ComponentModel.DataAnnotations;

namespace TimPortfolioApp.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}