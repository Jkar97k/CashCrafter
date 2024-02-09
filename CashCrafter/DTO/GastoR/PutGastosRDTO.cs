namespace CashCrafter.Api.DTO
{
    public class PutGastosRDTO
    {
        public int UserId { get; set; }
        public int TpagoId { get; set; }
        public int CategoriaId { get; set; }
        public string Item { get; set; } 
        public string TImpuesto { get; set; }
       // public int Valor { get; set; } = 0;
       // public int Fpago { get; set; } = 0;
       // public string Descripcion { get; set; }
    }
}
