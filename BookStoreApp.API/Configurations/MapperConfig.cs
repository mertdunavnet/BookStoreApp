using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Dtos.Authors;
using BookStoreApp.API.Dtos.Books;
using BookStoreApp.API.Dtos.User;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            CreateMap<ResultAuthorDto, Author>().ReverseMap();

            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            CreateMap<Book, ResultBookDto>()
                    .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                    .ReverseMap();

            CreateMap<Book, ResultBookDetailsDto>()
                    .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                    .ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
