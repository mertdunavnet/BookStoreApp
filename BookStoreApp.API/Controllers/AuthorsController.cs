using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Dtos.Authors;
using AutoMapper;
using BookStoreApp.API.Static;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using AutoMapper.QueryableExtensions;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> logger;

        public AuthorsController(BookStoreDbContext context, IMapper mapper, ILogger<AuthorsController> logger)
        {
            _context = context;
            _mapper = mapper;
            this.logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<List<ResultAuthorDto>>> GetAuthors()
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();
                var response = _mapper.Map<List<ResultAuthorDto>>(authors);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsWithBooksDto>> GetAuthor(int id)
        {
            try
            {
                var author = await _context.Authors
                    .Include(q => q.Books)
                    .ProjectTo<AuthorDetailsWithBooksDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.Id == id);

                if (author == null)
                {
                    logger.LogWarning($"Record Not Found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(int id, UpdateAuthorDto request)
        {
            if (id != request.Id)
            {
                logger.LogWarning($"Update ID invalid in {nameof(PutAuthor)} - ID: {id}");
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                logger.LogWarning($"{nameof(Author)} record not found in {nameof(PutAuthor)} - ID: {id}");
                return NotFound();
            }

            _mapper.Map(request, author);
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(request);
        }

        // POST: api/Authors
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CreateAuthorDto>> PostAuthor(CreateAuthorDto request)
        {
            try
            {
                var author = _mapper.Map<Author>(request);
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();

                return Ok(author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(PostAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    logger.LogWarning($"{nameof(Author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return Ok($"{id}: number data deleted successfully!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await _context.Authors.AnyAsync(e => e.Id == id);
        }
    }
}
