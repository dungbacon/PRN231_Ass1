using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;


        public BookController(IBookRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet("books")]
        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            var list = await repository.GetBooks();
            return Ok(list);
        }

        [HttpGet("books/{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookByID(int id)
        {
            var item = await repository.GetBookByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("books/create")]
        [Authorize]
        public async Task<IActionResult> PostBook([FromBody] BookRequestDTO info)
        {
            await repository.SaveBook(mapper.Map<Book>(info));
            return Ok();
        }

        [HttpPut("books/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook([FromBody] BookRequestDTO info, int id)
        {
            var item = await repository.GetBookByID(id);
            if (item == null)
            {
                return NotFound();
            }
            var ans = mapper.Map(info, item);
            await repository.UpdateBook(ans);
            return Ok();
        }


        [HttpDelete("books/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var item = await repository.GetBookByID(id);
            if (item == null)
            {
                return NotFound();
            }
            await repository.DeleteBook(item);
            return Ok();
        }
    }
}
