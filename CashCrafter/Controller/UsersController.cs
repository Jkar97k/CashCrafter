using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashCrafter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var dto = await _userService.Get();

            if (_userService.StatusCode != 200)
                return StatusCode(_userService.StatusCode, _userService.Informacion);

            return Ok(new { Respuesta = dto, Mensaje = _userService.Informacion });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _userService.GetById(id);

            if (_userService.StatusCode != 200)
                return StatusCode(_userService.StatusCode, _userService.Informacion);

            return Ok(dto);
        }

        // POST api/<MarcasController>
        [HttpPost]
        public async Task<ActionResult> Create(PostUserDTO dto)
        {
            await _userService.Create(dto);

            if (_userService.StatusCode != 200)
                return StatusCode(_userService.StatusCode, _userService.Informacion);

            return Ok(new { Mensaje = _userService.Informacion });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PutUserDTO dto)
        {
            await _userService.Update(id, dto);

            if (_userService.StatusCode != 200)
                return StatusCode(_userService.StatusCode, _userService.Informacion);

            return Ok(new { Mensaje = _userService.Informacion });

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);

            if (_userService.StatusCode != 200)
                return StatusCode(_userService.StatusCode, _userService.Informacion);

            return Ok(new { Mensaje = _userService.Informacion });
        }
    }
}
