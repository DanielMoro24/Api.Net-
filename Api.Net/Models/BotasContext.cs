using Microsoft.EntityFrameworkCore;

namespace Api.Net.Models
{
    public class BotasContext : DbContext
    {
       public BotasContext(DbContextOptions<BotasContext> options)
            : base(options)
        {
        }

        public DbSet<botasFutbol> BotasFutbols { get; set; }
    }
}
