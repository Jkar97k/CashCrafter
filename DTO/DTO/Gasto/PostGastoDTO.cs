namespace CashCrafter.DTO
{
    public class PostGastoDTO
    {
        public int UserId { get; set; } = 1;
        public int Mes { get; set; } = 0;
        public int TpagoId { get; set; } = 0;
        public int CategoriaId { get; set; } = 0;
        public string Item { get; set; }
        public string TImpuesto { get; set; }
        public int Valor { get; set; } = 0;
        public int Fpago { get; set; } = 0;
        public string Descripcion { get; set; }
    }
}
