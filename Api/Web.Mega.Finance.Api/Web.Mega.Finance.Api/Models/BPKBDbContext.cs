using Microsoft.EntityFrameworkCore;

namespace Web.Mega.Finance.Api.Models
{
    public class BPKBDbContext : MegaFinanceContext
    {
        public BPKBDbContext(DbContextOptions<MegaFinanceContext> options) : base(options)
        {
        }

        public BPKBDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.GetConnectionString("DefaultConnection"));
        }
    }
}
