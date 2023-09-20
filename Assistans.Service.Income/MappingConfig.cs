using Assistans.Service.IncomeAPI.Models;
using AutoMapper;

namespace Assistant.Service.IncomeAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<IncomeDto, Income>();
                config.CreateMap<Income, IncomeDto>();
            });
            return mappingConfig;
        }
    }
}
