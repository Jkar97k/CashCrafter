using CashCrafter.DTO;
using CashCrafter.Service;
using Microsoft.AspNetCore.Mvc;

namespace CashCrafter.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposAhorroController : ControllerBase
    {
        private readonly ITipoAhorroService _tipoahorroservice;

        public TiposAhorroController(ITipoAhorroService tipoahorroservice)
        {
            _tipoahorroservice = tipoahorroservice;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _tipoahorroservice.Get();

            if (_tipoahorroservice.StatusCode != 200)
                return StatusCode(_tipoahorroservice.StatusCode, _tipoahorroservice.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _tipoahorroservice.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _tipoahorroservice.GetById(id);

            if (_tipoahorroservice.StatusCode != 200)
                return StatusCode(_tipoahorroservice.StatusCode, _tipoahorroservice.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostTipoAhorroDTO dto)
        {
            await _tipoahorroservice.Create(dto);

            if (_tipoahorroservice.StatusCode != 200)
                return StatusCode(_tipoahorroservice.StatusCode, _tipoahorroservice.Informacion);

            return Ok(new { Mensaje = _tipoahorroservice.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostTipoAhorroDTO dto)
        {
            await _tipoahorroservice.Update(id, dto);

            if (_tipoahorroservice.StatusCode != 200)
                return StatusCode(_tipoahorroservice.StatusCode, _tipoahorroservice.Informacion);

            return Ok(new { Mensaje = _tipoahorroservice.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tipoahorroservice.Delete(id);

            if (_tipoahorroservice.StatusCode != 200)
                return StatusCode(_tipoahorroservice.StatusCode, _tipoahorroservice.Informacion);

            return Ok(new { Mensaje = _tipoahorroservice.Informacion });
        }
    }
}
