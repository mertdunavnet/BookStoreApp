using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public BookService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage, client)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateBook(CreateBookDto Book)
        {
            Response<int> response = new Response<int> { Success = true };

            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(Book);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> EditBook(int id, UpdateBookDto Book)
        {
            Response<int> response = new Response<int> { Success = false };

            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(id, Book);
                response.Success = true; // Ensure success is set correctly
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<ResultBookDetailsDto>> GetBook(int id)
        {
            Response<ResultBookDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<ResultBookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<ResultBookDetailsDto>(exception);
            }

            return response;
        }

        public async Task<Response<List<ResultBookDto>>> GetBooks()
        {
            Response<List<ResultBookDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<ResultBookDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<ResultBookDto>>(exception);
            }

            return response;
        }

        public async Task<Response<UpdateBookDto>> GetBookForUpdate(int id)
        {
            Response<UpdateBookDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<UpdateBookDto>
                {
                    Data = mapper.Map<UpdateBookDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<UpdateBookDto>(exception);
            }

            return response;
        }

        public async Task<Response<int>> DeleteBook(int id)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.BooksDELETEAsync(id);
                response.Success = true;
                response.Data = 200;
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
    }
}
