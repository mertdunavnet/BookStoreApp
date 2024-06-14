using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<ResultAuthorDto>>> GetAuthors();
        Task<Response<AuthorDetailsWithBooksDto>> GetAuthor(int id);
        Task<Response<UpdateAuthorDto>> GetAuthorForUpdate(int id);
        Task<Response<int>> CreateAuthor(CreateAuthorDto author);
        Task<Response<int>> EditAuthor(int id, UpdateAuthorDto author);
        Task<Response<int>> DeleteAuthor(int id);
    }
}