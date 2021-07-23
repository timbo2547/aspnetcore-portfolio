using System.Collections.Generic;
using System.Threading.Tasks;
using TimPortfolioApp.Dtos;
using TimPortfolioApp.Models;

namespace TimPortfolioApp.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> InsertCategoryAsync(Category category);
        Task<Category> InsertCategoryDtoAsync(NewCategoryDto category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
