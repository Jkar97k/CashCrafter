﻿namespace CashCrafter.Api.DTO
{
    public class TipoPagoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Entidad { get; set; }
        public int FechaCorte { get; set; }
    }
}