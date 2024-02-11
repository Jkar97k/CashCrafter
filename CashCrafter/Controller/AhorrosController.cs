using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AhorrosController : ControllerBase
    {
        private readonly IAhorroService _ahorroservice;

        public AhorrosController(IAhorroService ahorroservice)
        {
            _ahorroservice = ahorroservice;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _ahorroservice.Get();

            if (_ahorroservice.StatusCode != 200)
                return StatusCode(_ahorroservice.StatusCode, _ahorroservice.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _ahorroservice.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _ahorroservice.GetById(id);

            if (_ahorroservice.StatusCode != 200)
                return StatusCode(_ahorroservice.StatusCode, _ahorroservice.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostAhorroDTO dto)
        {
            await _ahorroservice.Create(dto);

            if (_ahorroservice.StatusCode != 200)
                return StatusCode(_ahorroservice.StatusCode, _ahorroservice.Informacion);

            return Ok(new { Mensaje = _ahorroservice.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostAhorroDTO dto)
        {
            await _ahorroservice.Update(id, dto);

            if (_ahorroservice.StatusCode != 200)
                return StatusCode(_ahorroservice.StatusCode, _ahorroservice.Informacion);

            return Ok(new { Mensaje = _ahorroservice.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ahorroservice.Delete(id);

            if (_ahorroservice.StatusCode != 200)
                return StatusCode(_ahorroservice.StatusCode, _ahorroservice.Informacion);

            return Ok(new { Mensaje = _ahorroservice.Informacion });
        }
    }
}
