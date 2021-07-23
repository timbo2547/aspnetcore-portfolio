using System.Collections.Generic;
using System.Threading.Tasks;
using TimPortfolioApp.Dtos;
using TimPortfolioApp.Models;

namespace TimPortfolioApp.Repository
{
    public interface ISampleItemRepository
    {
        Task<List<SampleItem>> GetSampleItemsAsync();
        Task<SampleItem> GetSampleItemAsync(int id);
        Task<SampleItem> InsertSampleItemDtoAsync(NewSampleItemDto sampleItem);
        Task<bool> UpdateSampleItemAsync(SampleItem sampleItem);
        Task<bool> DeleteSampleItemAsync(int id);
    }
}
