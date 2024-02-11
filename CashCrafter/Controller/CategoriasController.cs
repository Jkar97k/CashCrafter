using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _categoriaService.Get();

            if (_categoriaService.StatusCode != 200)
                return StatusCode(_categoriaService.StatusCode, _categoriaService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _categoriaService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _categoriaService.GetById(id);

            if (_categoriaService.StatusCode != 200)
                return StatusCode(_categoriaService.StatusCode, _categoriaService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostCategoriaDTO dto)
        {
            await _categoriaService.Create(dto);

            if (_categoriaService.StatusCode != 200)
                return StatusCode(_categoriaService.StatusCode, _categoriaService.Informacion);

            return Ok(new { Mensaje = _categoriaService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostCategoriaDTO dto)
        {
            await _categoriaService.Update(id, dto);

            if (_categoriaService.StatusCode != 200)
                return StatusCode(_categoriaService.StatusCode, _categoriaService.Informacion);

            return Ok(new { Mensaje = _categoriaService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoriaService.Delete(id);

            if (_categoriaService.StatusCode != 200)
                return StatusCode(_categoriaService.StatusCode, _categoriaService.Informacion);

            return Ok(new { Mensaje = _categoriaService.Informacion });
        }
    }
}
