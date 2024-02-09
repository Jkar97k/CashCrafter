namespace CashCrafter.Api.DTO
{
    public class AhorroDTO
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int TAhorroId { get; set; }
        public string Donde { get; set; }
        public string Descripcion { get; set; }
        public int FIngreso { get; set; }
        public int FRetiro { get; set; }
        public int UserId { get; set; }
    }
}
