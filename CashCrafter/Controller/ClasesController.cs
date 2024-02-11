using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly IClaseService _claseService;

        public ClasesController(IClaseService claseService)
        {
            _claseService = claseService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _claseService.Get();

            if (_claseService.StatusCode != 200)
                return StatusCode(_claseService.StatusCode, _claseService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _claseService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _claseService.GetById(id);

            if (_claseService.StatusCode != 200)
                return StatusCode(_claseService.StatusCode, _claseService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostClaseDTO dto)
        {
            await _claseService.Create(dto);

            if (_claseService.StatusCode != 200)
                return StatusCode(_claseService.StatusCode, _claseService.Informacion);

            return Ok(new { Mensaje = _claseService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostClaseDTO dto)
        {
            await _claseService.Update(id, dto);

            if (_claseService.StatusCode != 200)
                return StatusCode(_claseService.StatusCode, _claseService.Informacion);

            return Ok(new { Mensaje = _claseService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _claseService.Delete(id);

            if (_claseService.StatusCode != 200)
                return StatusCode(_claseService.StatusCode, _claseService.Informacion);

            return Ok(new { Mensaje = _claseService.Informacion });
        }
    }
}
