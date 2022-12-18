using Domain.Entities;
using Domain.Entities.OfferentPreferences;
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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Cleaning> CleaningOffers { get; set; }
        public DbSet<CleaningPreference> CleaningPreferences { get; set; }
        public DbSet<CarpetWashing> CarpetWashingOffers { get; set; }
        public DbSet<CarpetWashingPreference> CarpetWashingPreferences { get; set; }
        public DbSet<WindowsCleaning> WindowsCleaningOffers { get; set; }
        public DbSet<WindowsCleaningPreference> WindowsCleaningPreferences { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seeker>(eb =>
            {
                eb.Property(u => u.Name).HasMaxLength(25).IsRequired();
                eb.Property(u => u.Email).IsRequired();
              
 

            });
            modelBuilder.Entity<Offerent>(eb =>
            {
                eb.Property(u => u.Name).HasMaxLength(25).IsRequired();
                eb.Property(u => u.Email).IsRequired();
            

            });

            modelBuilder.Entity<CarpetWashing>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.Property(d => d.CarpetCount).IsRequired();
                eb.HasOne(d => d.Seeker).WithMany(o => o.CarpetWaschingOffers).HasForeignKey(d => d.SeekerId);
                //eb.HasMany(d => d.Addresses).WithOne(o => o.CarpetWashing).HasForeignKey(s => s.CarpetWashingId);
            });

            

            modelBuilder.Entity<Cleaning>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.Property(d => d.SurfaceToClean).IsRequired();
                eb.HasOne(d => d.Seeker).WithMany(o => o.CleaningOffers).HasForeignKey(d => d.SeekerId);
                //eb.HasMany(d => d.Addresses).WithOne(o => o.Cleaning).HasForeignKey(s => s.CleaningId);

            });
            modelBuilder.Entity<CleaningPreference>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                eb.Property(o => o.Regularity).IsRequired();
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.HasOne(d => d.Offerent).WithMany(o => o.CleaningPreferences).HasForeignKey(d => d.OfferentId);


            });
            modelBuilder.Entity<CarpetWashingPreference>(eb =>
            {
                eb.Property(o => o.Name).IsRequired();
                
                eb.Property(o => o.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(o => o.UpdateDate).ValueGeneratedOnUpdate();
                eb.HasOne(d => d.Offerent).WithMany(o => o.CarpetWashingPreferences).HasForeignKey(d => d.OfferentId);


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
                    PhoneNumber = "234123111",
                });

            modelBuilder.Entity<Seeker>()
                .HasData(new Seeker { Name = "Romuald Krawczyk", Id = 1, Email = "jdsks@com", PhoneNumber = "123456" }, new Seeker
                {
                    Name = "Alicja Olos",
                    Id = 2,
                    Email = "Ania@pl",
                    PhoneNumber = "234123111"
                });
            modelBuilder.Entity<Address>()
                .HasData(new Address()
                {
                    Id = 1,
                    
                    City = "Orzesze",
                    Street = "Dworcowa",
                    PostalCode = "43-190"
                });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 2,
                   
                   City = "Mikołów",
                   Street = "Majowa",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 3,
                   
                   City = "Katowice",
                   Street = "Głogowa",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Location>()
            .HasData(new Location
                {
                    Id = 1,
                    City = "Katowice",
                    District = "Bogucice"

            });
            modelBuilder.Entity<Location>()
               .HasData(new Location
               {
                   Id = 2,
                   City = "Bytom",
                   District = "Szombierki"

            });
        
            modelBuilder.Entity<Location>()
               .HasData(new Location
               {
                   Id = 3,
                   City = "Katowice",
                   District = "Ligota"

            });

            modelBuilder.Entity<Cleaning>()
                .HasData(new Cleaning {
                    Id = 1, 
                    CreatedDate = DateTime.UtcNow,
                    SeekerId = 1, 
         
                    Regularity = Domain.Entities.Utils.Regularity.OnceAWeek,
                    SurfaceToClean = 100,
                    AddressId = 1
                });
 
            modelBuilder.Entity<CarpetWashing>()
                .HasData(new CarpetWashing
                {
                    Id = 1,
                    CreatedDate = DateTime.UtcNow,
                    SeekerId = 1,
                    
                    CarpetCount = 1,
                    AddressId = 2
                });
            modelBuilder.Entity<WindowsCleaning>()
               .HasData(new WindowsCleaning
               {
                   Id = 1,
                   CreatedDate = DateTime.UtcNow,
                   SeekerId = 1,
                   
                   WindowsCount = 15,
                   AddressId = 3

               });
            
            modelBuilder.Entity<CleaningPreference>()
               .HasData(new CleaningPreference
               {
                   Id = 1,
                   CreatedDate = DateTime.UtcNow,
                   OfferentId = 1,
                   PriceOffer = 800,
                   LocationId = 1

               });
            modelBuilder.Entity<CarpetWashingPreference>()
              .HasData(new CarpetWashingPreference
              {
                  Id = 1,
                  CreatedDate = DateTime.UtcNow,
                  OfferentId = 2,
                  PriceOffer = 200,
                  LocationId = 2

              });
            modelBuilder.Entity<WindowsCleaningPreference>()
              .HasData(new WindowsCleaningPreference
              {
                  Id = 1,
                  CreatedDate = DateTime.UtcNow,
                  OfferentId = 2,
                  PriceOffer = 2000,
                  LocationId = 3

              });



        }
    }
   
}

