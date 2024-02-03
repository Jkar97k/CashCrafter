using CashCrafter.Api.Interfaces;

namespace CashCrafter.Api.Service
{
    public class Mensaje : IMensaje
    {
        public string Informacion { get; set; }
        public int StatusCode { get; set; }
    }
}
