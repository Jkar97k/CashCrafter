namespace CashCrafter.Api.Model
{
    public class GastoR
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int ClaseId { get; set; }
        public string Item { get; set; }
        public int VReal { get; set; }
        public int VEstimado { get; set; }
        public string Descripcion { get; set; }
        public int UserId { get; set; }
        public int Fpago { get; set; }
    }
}
