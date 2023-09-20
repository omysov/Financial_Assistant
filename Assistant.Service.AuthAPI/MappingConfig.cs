using AutoMapper;

namespace Assistant.Service.AuthAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<string, string>();
            });
            return mappingConfig;
        }
    }
}
