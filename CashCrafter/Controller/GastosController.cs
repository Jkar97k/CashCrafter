using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IGastoService _gastoService;

        public GastosController(IGastoService gastoService)
        {
            _gastoService = gastoService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _gastoService.Get();

            if (_gastoService.StatusCode != 200)
                return StatusCode(_gastoService.StatusCode, _gastoService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _gastoService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _gastoService.GetById(id);

            if (_gastoService.StatusCode != 200)
                return StatusCode(_gastoService.StatusCode, _gastoService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostGastoDTO dto)
        {
            await _gastoService.Create(dto);

            if (_gastoService.StatusCode != 200)
                return StatusCode(_gastoService.StatusCode, _gastoService.Informacion);

            return Ok(new { Mensaje = _gastoService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PutGastoDTO dto)
        {
            await _gastoService.Update(id, dto);

            if (_gastoService.StatusCode != 200)
                return StatusCode(_gastoService.StatusCode, _gastoService.Informacion);

            return Ok(new { Mensaje = _gastoService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _gastoService.Delete(id);

            if (_gastoService.StatusCode != 200)
                return StatusCode(_gastoService.StatusCode, _gastoService.Informacion);

            return Ok(new { Mensaje = _gastoService.Informacion });
        }
    }
}
