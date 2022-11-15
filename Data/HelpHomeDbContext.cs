using Domain.Entities;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data 
{
    public class HelpHomeDbContext : DbContext
    {
        public HelpHomeDbContext(DbContextOptions<HelpHomeDbContext> options) : base(options)
        {

        }
       
        public DbSet<Seeker> Seekers { get; set; }
        public DbSet<Offerent> Oferrents { get; set; }
        public DbSet<Address> Addresses { get; set; }
       
        public DbSet<Cleaning> CleaningOffers { get; set; }
        public DbSet<CarpetWashing> CarpetWashingOffers { get; set; }
        public DbSet<WindowsCleaning> WindowsCleaningOffers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seeker>(eb =>
            {
                eb.Property(u => u.Name).IsRequired();
                eb.Property(u => u.Email).IsRequired();
                eb.Property(u => u.Name).HasMaxLength(25);
 
                eb.HasOne(u => u.Address).WithOne(t => t.Seeker).HasForeignKey<Seeker>(u => u.AddressId);
            });
            modelBuilder.Entity<Offerent>(eb =>
            {
                eb.Property(u => u.Name).IsRequired();
                eb.Property(u => u.Email).IsRequired();
                eb.Property(u => u.preferences).IsRequired();
                eb.Property(u => u.Name).HasMaxLength(25);
                eb.Property(u => u.Area).IsRequired();
                eb.Property(u => u.Address).IsRequired();
                eb.HasOne(u => u.Address).WithOne(t => t.Offerent).HasForeignKey<Offerent>(u => u.AddressId);


            });

            modelBuilder.Entity<CarpetWashing>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.Property(d => d.CarpetCount).IsRequired();
                eb.HasOne(d => d.Seeker).WithMany(o => o.CarpetWaschingOffers).HasForeignKey(d => d.SeekerId);
            });
        

            modelBuilder.Entity<Cleaning>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.Property(d => d.SurfaceToClean).IsRequired();
                eb.HasOne(d => d.Seeker).WithMany(o => o.CleaningOffers).HasForeignKey(d => d.SeekerId);
            });

            modelBuilder.Entity<WindowsCleaning>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.Property(d => d.WindowsCount).IsRequired();
                eb.HasOne(d => d.Seeker).WithMany(o => o.WindowsCleaningOffers).HasForeignKey(d => d.SeekerId);
            });
        

            modelBuilder.Entity<Offerent>()
                .HasData(new Offerent { Name = "Jan Kowalski", Id = 1, Email = "jdsks@com", PhoneNumber = "123456" }, new Offerent
                {
                    Name = "Ania Nowak",
                    Id = 2,
                    Email = "Ania@pl",
                    PhoneNumber = "234123111"
                });
            modelBuilder.Entity<Seeker>()
                .HasData(new Seeker { Name = "Romuald Krawczyk", Id = 1, Email = "jdsks@com", PhoneNumber = "123456" }, new Seeker
                {
                    Name = "Alicja Olos",
                    Id = 2,
                    Email = "Ania@pl",
                    PhoneNumber = "234123111"
                });

            modelBuilder.Entity<Cleaning>()
                .HasData(new Cleaning {
                    Id = 1, 
                    CreatedDate = DateTime.UtcNow,
                    SeekerId = 1, 
                    PriceOffer = 50,
                    Regularity = Domain.Entities.Utils.Regularity.OnceAWeek,
                    SurfaceToClean = 100
                });
        }
    }
}

