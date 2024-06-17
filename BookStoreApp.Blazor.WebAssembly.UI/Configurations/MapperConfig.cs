using AutoMapper;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ResultAuthorDto, UpdateAuthorDto>().ReverseMap();
            CreateMap<ResultBookDetailsDto, UpdateBookDto>().ReverseMap();
        }
    }
}
