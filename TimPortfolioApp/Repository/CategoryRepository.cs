using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimPortfolioApp.Dtos;
using TimPortfolioApp.Models;

namespace TimPortfolioApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PostgresDbContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public CategoryRepository(PostgresDbContext context, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("CategoryRepository");
            _mapper = mapper;
        }
        public async Task<Category> InsertCategoryAsync(Category category)
        {
            _context.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertCategoryAsync)}: " + exp.Message);
            }
            return category;
        }
        public async Task<Category> InsertCategoryDtoAsync(NewCategoryDto categoryDto)
        {
            var c = _mapper.Map<NewCategoryDto, Category>(categoryDto);
            _context.Add(c);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertCategoryDtoAsync)}: " + exp.Message);
            }
            return c;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Include(x => x.SampleItems).OrderBy(c => c.CategoryName).ToListAsync();
        }
        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.Include(x => x.SampleItems).SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            _context.Remove(category);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeleteCategoryAsync)}: " + exp.Message);
            }
            return false;
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            //Will update all properties of the Category
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdateCategoryAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
