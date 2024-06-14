using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService 
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public AuthorService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage, client)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateAuthor(CreateAuthorDto author)
        {
            Response<int> response = new Response<int> { Success = true };

            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> EditAuthor(int id, UpdateAuthorDto author)
        {
            Response<int> response = new Response<int> { Success = false };

            try
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(id, author);
                response.Success = true; // Ensure success is set correctly
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<AuthorDetailsWithBooksDto>> GetAuthor(int id)
        {
            Response<AuthorDetailsWithBooksDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorDetailsWithBooksDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorDetailsWithBooksDto>(exception);
            }

            return response;
        }

        public async Task<Response<List<ResultAuthorDto>>> GetAuthors()
        {
            Response<List<ResultAuthorDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<ResultAuthorDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<ResultAuthorDto>>(exception);
            }

            return response;
        }

        public async Task<Response<UpdateAuthorDto>> GetAuthorForUpdate(int id)
        {
            Response<UpdateAuthorDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<UpdateAuthorDto>
                {
                    Data = mapper.Map<UpdateAuthorDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<UpdateAuthorDto>(exception);
            }

            return response;
        }

        public async Task<Response<int>> DeleteAuthor(int id)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.AuthorsDELETEAsync(id);
                response.Success = true;
                response.Data = 200;
            }
            catch(ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
    }
}
