﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(HelpHomeDbContext))]
    [Migration("20221127144743_AdministratorAdd")]
    partial class AdministratorAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OfferentId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Orzesze",
                            OfferentId = 1,
                            PostalCode = "43-190",
                            Street = "Dworcowa"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Utils.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Seeker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Offerent"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Administrator"
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

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Oferrents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdsks@com",
                            Name = "Jan Kowalski",
                            PasswordHash = "#1234#",
                            PhoneNumber = "123456",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Email = "agak@wp.pl",
                            Name = "Aga Kruk",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.CarpetWashing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasIndex("SeekerId");

                    b.ToTable("CarpetWashingOffers");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.Cleaning", b =>
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

                    b.HasIndex("SeekerId");

                    b.ToTable("CleaningOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 11, 27, 14, 47, 42, 512, DateTimeKind.Utc).AddTicks(4285),
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

                    b.HasIndex("SeekerId");

                    b.ToTable("WindowsCleaningOffers");
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

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Seekers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdsks@com",
                            Name = "Romuald Krawczyk",
                            PasswordHash = "#4566#",
                            PhoneNumber = "123456",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", "Offerent")
                        .WithMany("Addresses")
                        .HasForeignKey("OfferentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offerent");
                });

            modelBuilder.Entity("HelpHome.Entities.Offerent", b =>
                {
                    b.HasOne("Domain.Entities.Utils.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.CarpetWashing", b =>
                {
                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("CarpetWaschingOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.Cleaning", b =>
                {
                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("CleaningOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.WindowsCleaning", b =>
                {
                    b.HasOne("HelpHome.Entities.Seeker", "Seeker")
                        .WithMany("WindowsCleaningOffers")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.Seeker", b =>
                {
                    b.HasOne("HelpHome.Entities.Offerent", null)
                        .WithMany("BlockedSeekers")
                        .HasForeignKey("OfferentId");

                    b.HasOne("Domain.Entities.Utils.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HelpHome.Entities.Offerent", b =>
                {
                    b.Navigation("Addresses");

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
