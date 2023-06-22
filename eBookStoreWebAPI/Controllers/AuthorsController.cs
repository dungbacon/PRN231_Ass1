using AutoMapper;
using DataAccess.DTO;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthorsController : Controller
    {

        private readonly IAuthorRepository repository;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet("authors")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAuthors()
        {
            var list = await repository.GetAuthors();
            return Ok(list);
        }

        [HttpGet("authors/{id}")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAuthorByID(int id)
        {
            var item = await repository.GetAuthorByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("authors/create")]
        [Authorize]
        public async Task<IActionResult> PostAuthor([FromBody] AuthorDTO info)
        {
            var data = await repository.SaveAuthor(info);
            return Ok(data);
        }

        [HttpPut("authors/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorRequestDTO info, int id)
        {
            var item = await repository.GetAuthorByID(id);
            if (item == null)
            {
                return NotFound();
            }
            var ans = mapper.Map<AuthorDTO>(info);
            var data = await repository.UpdateAuthor(ans);
            return Ok(data);
        }

        [HttpDelete("authors/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var item = await repository.GetAuthorByID(id);
            if (item == null)
            {
                return NotFound();
            }
            await repository.DeleteAuthor(id);
            return Ok();
        }
    }
}
