using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Api.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        {
        }
    }
}
