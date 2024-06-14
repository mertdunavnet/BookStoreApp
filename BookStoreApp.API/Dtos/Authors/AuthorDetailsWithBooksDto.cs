using BookStoreApp.API.Dtos.Books;

namespace BookStoreApp.API.Dtos.Authors
{
    public class AuthorDetailsWithBooksDto : ResultAuthorDto
    {
        public List<ResultBookDto> Books { get; set; }
    }
}
