﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(HelpHomeDbContext))]
    partial class HelpHomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Orzesze",
                            PostalCode = "43-190",
                            Street = "Dworcowa"
                        },
                        new
                        {
                            Id = 2,
                            City = "Mikołów",
                            PostalCode = "43-190",
                            Street = "Majowa"
                        },
                        new
                        {
                            Id = 3,
                            City = "Katowice",
                            PostalCode = "43-190",
                            Street = "Głogowa"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.CarpetWashingPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarpetSize")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferentId")
                        .HasColumnType("int");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("CarpetWashingPreferences");
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.CleaningPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferentId")
                        .HasColumnType("int");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("CleaningPreferences");
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.WindowsCleaningPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferentId")
                        .HasColumnType("int");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("windowsCleaningPreferences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 11, 28, 17, 17, 36, 639, DateTimeKind.Utc).AddTicks(4456),
                            OfferentId = 1,
                            PriceOffer = 300,
                            Regularity = 0,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.Offerent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oferrents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdsks@com",
                            Name = "Jan Kowalski",
                            PhoneNumber = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Ania@pl",
                            Name = "Ania Nowak",
                            PhoneNumber = "234123111"
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.CarpetWashing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CarpetCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<int>("SeekerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SeekerId");

                    b.ToTable("CarpetWashingOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            CarpetCount = 1,
                            CreatedDate = new DateTime(2022, 11, 28, 17, 17, 36, 639, DateTimeKind.Utc).AddTicks(4409),
                            Name = "Pranie dywanów",
                            PriceOffer = 110,
                            Regularity = 0,
                            SeekerId = 1,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.Cleaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<int>("SeekerId")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceToClean")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SeekerId");

                    b.ToTable("CleaningOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CreatedDate = new DateTime(2022, 11, 28, 17, 17, 36, 639, DateTimeKind.Utc).AddTicks(4387),
                            Name = "Sprzątanie",
                            PriceOffer = 50,
                            Regularity = 0,
                            SeekerId = 1,
                            SurfaceToClean = 100,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.WindowsCleaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<int>("SeekerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("WindowsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SeekerId");

                    b.ToTable("WindowsCleaningOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 3,
                            CreatedDate = new DateTime(2022, 11, 28, 17, 17, 36, 639, DateTimeKind.Utc).AddTicks(4431),
                            Name = "Mycie okien",
                            PriceOffer = 50,
                            Regularity = 0,
                            SeekerId = 1,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WindowsCount = 15
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.Seeker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("OfferentId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("Seekers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdsks@com",
                            Name = "Romuald Krawczyk",
                            PhoneNumber = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Ania@pl",
                            Name = "Alicja Olos",
                            PhoneNumber = "234123111"
                        });
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.CarpetWashingPreference", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", "Offerent")
                        .WithMany()
                        .HasForeignKey("OfferentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offerent");
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.CleaningPreference", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", "Offerent")
                        .WithMany()
                        .HasForeignKey("OfferentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offerent");
                });

            modelBuilder.Entity("Domain.Entities.OfferentPreferences.WindowsCleaningPreference", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", "Offerent")
                        .WithMany()
                        .HasForeignKey("OfferentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offerent");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.CarpetWashing", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("CarpetWaschingOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.Cleaning", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("CleaningOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.WindowsCleaning", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("WindowsCleaningOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.Seeker", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", null)
                        .WithMany("BlockedSeekers")
                        .HasForeignKey("OfferentId");
                });

            modelBuilder.Entity("HelpHome.Entities.Offerent", b =>
                {
                    b.Navigation("BlockedSeekers");
                });

            modelBuilder.Entity("HelpHome.Entities.Seeker", b =>
                {
                    b.Navigation("CarpetWaschingOffers");

                    b.Navigation("CleaningOffers");

                    b.Navigation("WindowsCleaningOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
