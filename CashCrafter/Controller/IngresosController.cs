using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;


namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresoService _ingresoService;

        public IngresosController(IIngresoService ingresoService)
        {
            _ingresoService = ingresoService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _ingresoService.Get();

            if (_ingresoService.StatusCode != 200)
                return StatusCode(_ingresoService.StatusCode, _ingresoService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _ingresoService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _ingresoService.GetById(id);

            if (_ingresoService.StatusCode != 200)
                return StatusCode(_ingresoService.StatusCode, _ingresoService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostIngresosDTO dto)
        {
            await _ingresoService.Create(dto);

            if (_ingresoService.StatusCode != 200)
                return StatusCode(_ingresoService.StatusCode, _ingresoService.Informacion);

            return Ok(new { Mensaje = _ingresoService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostIngresosDTO dto)
        {
            await _ingresoService.Update(id, dto);

            if (_ingresoService.StatusCode != 200)
                return StatusCode(_ingresoService.StatusCode, _ingresoService.Informacion);

            return Ok(new { Mensaje = _ingresoService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ingresoService.Delete(id);

            if (_ingresoService.StatusCode != 200)
                return StatusCode(_ingresoService.StatusCode, _ingresoService.Informacion);

            return Ok(new { Mensaje = _ingresoService.Informacion });
        }
    }
}
