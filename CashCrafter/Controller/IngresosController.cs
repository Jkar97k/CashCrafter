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
    }
}
