using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionService _udbicacionService;

        public UbicacionesController(IUbicacionService udbicacionService)
        {
            _udbicacionService = udbicacionService;
        }

        // GET: api/<UbicacionesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _udbicacionService.Get();
            if (_udbicacionService.StatusCode != 200)
                return StatusCode(_udbicacionService.StatusCode, _udbicacionService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _udbicacionService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _udbicacionService.GetById(id);
            if (_udbicacionService.StatusCode != 200)
                return StatusCode(_udbicacionService.StatusCode, _udbicacionService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostUbicacionDTO dto)
        {
            await _udbicacionService.Create(dto);
            if (_udbicacionService.StatusCode != 200)
                return StatusCode(_udbicacionService.StatusCode, _udbicacionService.Informacion);

            return Ok(new { Mensaje = _udbicacionService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostUbicacionDTO dto)
        {
            await _udbicacionService.Update(id, dto);
            if (_udbicacionService.StatusCode != 200)
                return StatusCode(_udbicacionService.StatusCode, _udbicacionService.Informacion);

            return Ok(new { Mensaje = _udbicacionService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _udbicacionService.Delete(id);
            if (_udbicacionService.StatusCode != 200)
                return StatusCode(_udbicacionService.StatusCode, _udbicacionService.Informacion);

            return Ok(new { Mensaje = _udbicacionService.Informacion });
        }
    }
}
