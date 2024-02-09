using CashCrafter.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
