using Microsoft.EntityFrameworkCore;
using MerchatService.API.Domain.Entities;
using MerchatService.API.Domain.Common;

namespace MerchatService.API.Infrastructure.Database

{
    public class MerchantDbContext : DbContext
    {
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options) { }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>()
              .HasOne(e => e.ContactInformation)
              .WithOne(e => e.Merchant)
              .HasForeignKey<ContactInformation>(e => e.MerchantId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }

}
