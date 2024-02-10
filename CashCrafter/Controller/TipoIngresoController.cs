using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIngresoController : ControllerBase
    {
        private readonly ITipoIngresoService _tipoIngresoService;

         public TipoIngresoController(ITipoIngresoService tipoIngresoService)
        {
            _tipoIngresoService = tipoIngresoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _tipoIngresoService.Get();

            if (_tipoIngresoService.StatusCode != 200)
                return StatusCode(_tipoIngresoService.StatusCode, _tipoIngresoService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _tipoIngresoService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _tipoIngresoService.GetById(id);

            if (_tipoIngresoService.StatusCode != 200)
                return StatusCode(_tipoIngresoService.StatusCode, _tipoIngresoService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostTipoIngresoDTO dto)
        {
            await _tipoIngresoService.Create(dto);

            if (_tipoIngresoService.StatusCode != 200)
                return StatusCode(_tipoIngresoService.StatusCode, _tipoIngresoService.Informacion);

            return Ok(new { Mensaje = _tipoIngresoService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostTipoIngresoDTO dto)
        {
            await _tipoIngresoService.Update(id, dto);

            if (_tipoIngresoService.StatusCode != 200)
                return StatusCode(_tipoIngresoService.StatusCode, _tipoIngresoService.Informacion);

            return Ok(new { Mensaje = _tipoIngresoService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tipoIngresoService.Delete(id);

            if (_tipoIngresoService.StatusCode != 200)
                return StatusCode(_tipoIngresoService.StatusCode, _tipoIngresoService.Informacion);

            return Ok(new { Mensaje = _tipoIngresoService.Informacion });
        }
    }
}
