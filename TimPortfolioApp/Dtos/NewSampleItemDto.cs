using System.ComponentModel.DataAnnotations;

namespace TimPortfolioApp.Dtos
{
    public class NewSampleItemDto
    {
        [Required(ErrorMessage = "Please enter Sample Item name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public NewSampleItemCategoryDto Category { get; set; }
    }

    public class NewSampleItemCategoryDto
    {
        public int? Id { get; set; } 
        public string CategoryName { get; set; }
    }
}
