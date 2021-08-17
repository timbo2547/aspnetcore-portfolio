using System.ComponentModel.DataAnnotations;

namespace TimPortfolioApp.Models.ManageViewModels
{
    public class UpdateProfileViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}