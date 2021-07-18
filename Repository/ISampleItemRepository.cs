using AspNetCorePostgreSQLDockerApp.Dtos;
using AspNetCorePostgreSQLDockerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Repository
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
