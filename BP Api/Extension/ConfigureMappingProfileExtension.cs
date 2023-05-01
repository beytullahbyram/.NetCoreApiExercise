using AutoMapper;

namespace BP_Api.Extension
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig=new MapperConfiguration(i=>i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper=mappingConfig.CreateMapper();

            //Dependency injecktion
            service.AddSingleton(mapper);


            return service;
        }

        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                //Contact classı ContactDVO classına dönüştürme.
                CreateMap<BP_Api.Data.Models.Contact,BP_Api.Models.ContactDVO>()
                    .ForMember(x=>x.FullName,y=>y.MapFrom(z=>z.Name+" "+z.LastName))
                    //.ForMember(x=>x.ID,y=>y.MapFrom(z=>z.ID)) //değişken isimleri aynı ise yazmaya gerek yok
                    .ReverseMap();
                
            }
        }
    }
}
