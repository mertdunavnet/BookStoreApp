using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Dtos.Authors;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            CreateMap<ResultAuthorDto, Author>().ReverseMap();
        }
    }
}
