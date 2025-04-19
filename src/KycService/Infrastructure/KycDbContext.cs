using Microsoft.EntityFrameworkCore;

namespace KycService.Infrastructure.Database
{
    public class KycDbContext : DbContext
    {
        public KycDbContext(DbContextOptions<KycDbContext> options) : base(options)
        {

        }
    }

}
