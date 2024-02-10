using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosRController : ControllerBase
    {
        private readonly IGastosRService _gastosRService;

        public GastosRController(IGastosRService gastosRService)
        {
            _gastosRService = gastosRService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _gastosRService.Get();

            if (_gastosRService.StatusCode != 200)
                return StatusCode(_gastosRService.StatusCode, _gastosRService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _gastosRService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _gastosRService.GetById(id);

            if (_gastosRService.StatusCode != 200)
                return StatusCode(_gastosRService.StatusCode, _gastosRService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostGastosRDTO dto)
        {
            await _gastosRService.Create(dto);

            if (_gastosRService.StatusCode != 200)
                return StatusCode(_gastosRService.StatusCode, _gastosRService.Informacion);

            return Ok(new { Mensaje = _gastosRService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PutGastosRDTO dto)
        {
            await _gastosRService.Update(id, dto);

            if (_gastosRService.StatusCode != 200)
                return StatusCode(_gastosRService.StatusCode, _gastosRService.Informacion);

            return Ok(new { Mensaje = _gastosRService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _gastosRService.Delete(id);

            if (_gastosRService.StatusCode != 200)
                return StatusCode(_gastosRService.StatusCode, _gastosRService.Informacion);

            return Ok(new { Mensaje = _gastosRService.Informacion });
        }
    }
}
