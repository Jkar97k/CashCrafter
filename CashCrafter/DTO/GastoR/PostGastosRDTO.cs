namespace CashCrafter.Api.DTO
{
    public class PostGastosRDTO
    {
        public int UserId { get; set; }
        public int Mes { get; set; } = DateTime.Now.Month;
        public int TpagoId { get; set; }
        public int CategoriaId { get; set; }
        public string Item { get; set; } = "  ";
        public string TImpuesto { get; set; } = string.Empty;
        public int Valor { get; set; } = 0;
        public int Fpago { get; set; } = 0;
        public string Descripcion { get; set; } = "  ";
    }
}
