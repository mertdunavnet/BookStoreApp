using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<ResultBookDto>>> GetBooks();
        Task<Response<ResultBookDetailsDto>> GetBook(int id);
        Task<Response<UpdateBookDto>> GetBookForUpdate(int id);
        Task<Response<int>> CreateBook(CreateBookDto Book);
        Task<Response<int>> EditBook(int id, UpdateBookDto author);
        Task<Response<int>> DeleteBook(int id);
    }
}
