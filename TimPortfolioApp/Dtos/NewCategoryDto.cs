using System.ComponentModel.DataAnnotations;

namespace TimPortfolioApp.Dtos
{
    public class NewCategoryDto
    {
        [Required(ErrorMessage = "Please enter Category name")]
        [StringLength(255)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
