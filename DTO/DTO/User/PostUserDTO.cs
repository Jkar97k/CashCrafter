namespace CashCrafter.DTO;

public class PostUserDTO
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string NickName { get; set; }
    public string Correo { get; set; }
    public string Password { get; set; }
    public DateTime FecIngreso { get; set; } = DateTime.Now.Date;
}
