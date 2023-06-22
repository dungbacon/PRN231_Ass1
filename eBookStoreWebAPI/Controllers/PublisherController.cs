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
        [EnableQuery]
        public async Task<IActionResult> GetPublishers()
        {
            var list = await repository.GetPublishers();
            return Ok(list);
        }

        [HttpGet("publishers/{id}")]
        [Authorize]
        [EnableQuery]
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
        public async Task<IActionResult> PostPublisher([FromBody] PublisherRequestDTO info)
        {
            var data = await repository.SavePublisher(mapper.Map<PublisherDTO>(info));
            return Ok(data);
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
            var ans = mapper.Map<PublisherDTO>(info);
            var data = await repository.UpdatePublisher(ans);
            return Ok(data);
        }

        [HttpDelete("publishers/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var item = await repository.GetPublisherByID(id);
            if (item == null)
            {
                return NotFound();
            }
            await repository.DeletePublisher(id);
            return Ok();
        }
    }
}
