using CashCrafter.Service;

namespace CashCrafter.Service
{
    public class Mensaje : IMensaje
    {
        public string Informacion { get; set; }
        public int StatusCode { get; set; }
    }
}
