using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPagoController : ControllerBase
    {
        private readonly ITipoPagoService _tipoPagoService;

        public TiposPagoController(ITipoPagoService tipoPagoService)
        {
            _tipoPagoService = tipoPagoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _tipoPagoService.Get();

            if (_tipoPagoService.StatusCode != 200)
                return StatusCode(_tipoPagoService.StatusCode, _tipoPagoService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _tipoPagoService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _tipoPagoService.GetById(id);

            if (_tipoPagoService.StatusCode != 200)
                return StatusCode(_tipoPagoService.StatusCode, _tipoPagoService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostTipoPagoDTO dto)
        {
            await _tipoPagoService.Create(dto);

            if (_tipoPagoService.StatusCode != 200)
                return StatusCode(_tipoPagoService.StatusCode, _tipoPagoService.Informacion);

            return Ok(new { Mensaje = _tipoPagoService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostTipoPagoDTO dto)
        {
            await _tipoPagoService.Update(id, dto);

            if (_tipoPagoService.StatusCode != 200)
                return StatusCode(_tipoPagoService.StatusCode, _tipoPagoService.Informacion);

            return Ok(new { Mensaje = _tipoPagoService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tipoPagoService.Delete(id);

            if (_tipoPagoService.StatusCode != 200)
                return StatusCode(_tipoPagoService.StatusCode, _tipoPagoService.Informacion);

            return Ok(new { Mensaje = _tipoPagoService.Informacion });
        }
    }
}
