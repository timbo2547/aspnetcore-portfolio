using AutoMapper;
using TimPortfolioApp.Dtos;
using TimPortfolioApp.Models;

namespace TimPortfolioApp.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Category, NewCategoryDto>();

            // Dto to Domain
            CreateMap<NewCategoryDto, Category>();
            CreateMap<NewSampleItemDto, SampleItem>();
            CreateMap<NewSampleItemCategoryDto, Category>();
        }
    }
}
