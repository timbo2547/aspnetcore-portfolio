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
    public class SampleItemRepository : ISampleItemRepository
    {
        private readonly PostgresDbContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SampleItemRepository(PostgresDbContext context, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("SampleItemRepository");
            _mapper = mapper;
        }

        public async Task<List<SampleItem>> GetSampleItemsAsync()
        {
            return await _context.SampleItems.Include(x => x.Category).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<SampleItem> GetSampleItemAsync(int id)
        {
            return await _context.SampleItems.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<SampleItem> InsertSampleItemDtoAsync(NewSampleItemDto sampleItem)
        {
            //var category = _context.Categories.SingleOrDefault(c => c.Id == sampleItem.Category.Id);
            var category = sampleItem.Category.Id != 0 ? 
                _context.Categories.SingleOrDefault(c => c.Id == sampleItem.Category.Id) : 
                _context.Categories.SingleOrDefault(c => c.CategoryName == sampleItem.Category.CategoryName);

            if (category == null)
                return null;

            var newSampleItem = new SampleItem
            {
                Name = sampleItem.Name,
                Quantity = sampleItem.Quantity,
                Category = category
            };

            _context.Add(newSampleItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertSampleItemDtoAsync)}: " + exp.Message);
            }

            return newSampleItem;
        }

        public async Task<bool> UpdateSampleItemAsync(SampleItem sampleItem)
        {
            //Will update all properties of the Customer
            _context.SampleItems.Attach(sampleItem);
            _context.Entry(sampleItem).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdateSampleItemAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteSampleItemAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            var sampleItem = await _context.SampleItems.SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(sampleItem);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeleteSampleItemAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
