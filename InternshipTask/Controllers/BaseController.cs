using InternshipTask.Models;
using InternshipTask.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IGenericRepositoy<T> _repository;
        public BaseController(IGenericRepositoy<T> repositoy)
        {
            _repository = repositoy;
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create([FromBody] T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(int id, [FromBody] T entity)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _repository.Update(entity);
            await _repository.SaveAsync();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            _repository.Delete(entity);
            await _repository.SaveAsync();
            return NoContent();
        }   
    }
}
                                                                                                                            