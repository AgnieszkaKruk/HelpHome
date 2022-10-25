using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using Microsoft.EntityFrameworkCore;

namespace Data 
{
    public class HelpHomeDbContext : DbContext
    {
        public HelpHomeDbContext(DbContextOptions<HelpHomeDbContext> options) : base(options)
        {

        }
        DbSet<User> users { get; set; }
        DbSet<Seeker> seekers { get; set; }
        DbSet<Oferrent> oferrents { get; set; }
        DbSet<Offer> offers { get; set; }
        DbSet<Cleaning> cleaningOffers { get; set; }
        DbSet<CarpetWashing> carpetWashingOffers { get; set; }
        DbSet<WindowsCleaning> windowsCleaningOffers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(u => u.Name).IsRequired();
                eb.Property(u => u.Email).IsRequired();
                eb.Property(u => u.Name).HasMaxLength(25);
                eb.HasMany(u => u.offers).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            });


            modelBuilder.Entity<Offer>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<CarpetWashing>(eb =>
            {
                eb.Property(d => d.CarpetCount).IsRequired();
            });

            modelBuilder.Entity<Cleaning>(eb =>
            {
                eb.Property(d => d.SurfaceToClean).IsRequired();
            });

            modelBuilder.Entity<WindowsCleaning>(eb =>
            {
                eb.Property(d => d.WindowsCount).IsRequired();
            });
        }
    }
}

