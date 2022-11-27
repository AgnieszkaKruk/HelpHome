using Domain.Entities;
using Domain.Entities.Utils;
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
        public DbSet<Role> Roles { get; set; }

        public DbSet<Cleaning> CleaningOffers { get; set; }
        public DbSet<CarpetWashing> CarpetWashingOffers { get; set; }
        public DbSet<WindowsCleaning> WindowsCleaningOffers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(eb =>
            {
                eb.HasData(new Role
                {
                    Id = 1,
                    Name = "Seeker"
                }, new Role
                {
                    Id = 2,
                    Name = "Offerent"
                }, new Role
                {
                    Id = 3,
                    Name = "Administrator"
                }
                );
            });
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

            modelBuilder.Entity<Role>(eb =>
            {
                eb.Property(u => u.Name).IsRequired();

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

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasMaxLength(50);


            modelBuilder.Entity<Offerent>()
                .HasData(
                new Offerent {
                    Name = "Jan Kowalski",
                    Id = 1,
                    Email = "jdsks@com",
                    PhoneNumber = "123456",
                    PasswordHash = "#1234#",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "Aga Kruk",
                    Id = 2,
                    Email = "agak@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 3
                }
                );

            modelBuilder.Entity<Seeker>()
                .HasData(new Seeker { Name = "Romuald Krawczyk", Id = 1, Email = "jdsks@com", PhoneNumber = "123456", PasswordHash = "#4566#", RoleId = 1 }
             
                );

            modelBuilder.Entity<Cleaning>()
                .HasData(new Cleaning
                {
                    Id = 1,
                    CreatedDate = DateTime.UtcNow,
                    SeekerId = 1,
                    PriceOffer = 50,
                    Regularity = Domain.Entities.Utils.Regularity.OnceAWeek,
                    SurfaceToClean = 100
                });
            modelBuilder.Entity<Address>()
                .HasData(new Address()
                {
                    Id = 1,
                    OfferentId = 1,
                    City = "Orzesze",
                    Street = "Dworcowa",
                    PostalCode = "43-190"
                });
        }
    }

}

