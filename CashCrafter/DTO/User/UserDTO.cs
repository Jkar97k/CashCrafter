namespace CashCrafter.Api.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NickName { get; set; }
        public string Correo { get; set; }
        public DateTime FecIngreso { get; set; }
    }
}
