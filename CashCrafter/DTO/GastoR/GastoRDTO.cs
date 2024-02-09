namespace CashCrafter.Api.DTO
{
    public class GastoRDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Mes { get; set; }
        public int TpagoId { get; set; }
        public int CategoriaId { get; set; }
        public string Item { get; set; }
        public string TImpuesto { get; set; }
        public int Valor { get; set; }
        public int Fpago { get; set; }
        public string Descripcion { get; set; }
    }
}
