
using CashCrafter.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        {
        }
        public DbSet<Abono> Abonos { get; set; }
        public DbSet<Ahorro> Ahorros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<GastoR> GastosR { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<TipoAhorro> TiposAhorro { get; set; }
        public DbSet<TipoIngreso> TiposIngresos { get; set; }
        public DbSet<TipoPago> TiposPago { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
