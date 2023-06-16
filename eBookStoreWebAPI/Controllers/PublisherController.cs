using AutoMapper;
using BusinessObject.Models;
using BusinessObject.Models.Enum;
using DataAccess.DTO;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository repository;
        private readonly IMapper mapper;

        public PublisherController(IPublisherRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet("publishers")]
        [Authorize]
        public async Task<IActionResult> GetPublishers()
        {
            var list = await repository.GetPublishers();
            return Ok(list);
        }

        [HttpGet("publishers/{id}")]
        [Authorize]
        public async Task<IActionResult> GetPublisherByID(int id)
        {
            var item = await repository.GetPublisherByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("publishers/create")]
        [Authorize]
        public IActionResult PostPublisher([FromBody] PublisherRequestDTO info)
        {
            repository.SavePublisher(mapper.Map<Publisher>(info));
            return Ok();
        }

        [HttpPut("publishers/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePublisher([FromBody] PublisherRequestDTO info, int id)
        {
            var item = await repository.GetPublisherByID(id);
            if (item == null)
            {
                return NotFound();
            }
            var ans = mapper.Map(info, item);
            await repository.UpdatePublisher(ans);
            return Ok();
        }

        [HttpDelete("publishers/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var session = HttpContext.Session;
            var role = session.GetString("role");
            if (role == RoleType.admin.ToString())
            {
                var item = await repository.GetPublisherByID(id);
                if (item == null)
                {
                    return NotFound();
                }
                await repository.DeletePublisher(item);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
