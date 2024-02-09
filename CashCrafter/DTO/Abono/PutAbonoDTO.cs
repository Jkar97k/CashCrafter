namespace CashCrafter.Api.DTO.Abono
{
    public class PutAbonoDTO
    {
        public int UserId { get; set; }
        public int Mes { get; set; }
        public int GastoId { get; set; }
        public int Valor { get; set; }
        public int FPago { get; set; }
        public string Descripcion { get; set; }
        public int UbicacionId { get; set; }
    }
}
