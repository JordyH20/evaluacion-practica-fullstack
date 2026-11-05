using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaFullStack.DTOs.Request;
using PruebaFullStack.Service;

namespace PruebaFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _service;

        public ComentarioController(ComentarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comentario = await _service.GetByIdAsync(id);

            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }



        [HttpPost]
        public async Task<IActionResult> Create(ComentarioRequest request)
        {
            var comentario = await _service.CreateAsync(request);
            return Ok(comentario);
        }




        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ComentarioRequest request)
        {
            var result = await _service.UpdateAsync(id, request);

            if (!result)
                return NotFound();

            return NoContent();
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
