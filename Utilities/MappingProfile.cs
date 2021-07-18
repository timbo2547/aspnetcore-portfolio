using AspNetCorePostgreSQLDockerApp.Dtos;
using AspNetCorePostgreSQLDockerApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Utilities
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
