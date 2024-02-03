namespace CashCrafter.Api.Model
{
    public class Ingreso
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int TIngresoId { get; set; }
        public string Descripcion { get; set; }
        public int UserId { get; set; }

    }
}
