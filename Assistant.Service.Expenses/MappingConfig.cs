using Assistans.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Models.Dto;
using AutoMapper;

namespace Assistant.Service.ExpensesAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ExpensesDto, Expenses>();
                config.CreateMap<Expenses, ExpensesDto>();
                config.CreateMap<CategoryDto, Category>();
                config.CreateMap<Category, CategoryDto>();
            });
            return mappingConfig;
        }
    }
}
