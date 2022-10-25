﻿// <auto-generated />
using System;
using HelpHome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelpHome.Migrations
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

            modelBuilder.Entity("HelpHome.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int>("Regularity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("offers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Offer");
                });

            modelBuilder.Entity("HelpHome.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("HelpHome.Entities.Oferrent", b =>
                {
                    b.HasBaseType("HelpHome.Entities.User");

                    b.HasDiscriminator().HasValue("Oferrent");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.CarpetWashing", b =>
                {
                    b.HasBaseType("HelpHome.Entities.Offer");

                    b.Property<int>("CarpetCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CarpetWashing");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.Cleaning", b =>
                {
                    b.HasBaseType("HelpHome.Entities.Offer");

                    b.Property<int>("SurfaceToClean")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cleaning");
                });

            modelBuilder.Entity("HelpHome.Entities.OfferTypes.WindowsCleaning", b =>
                {
                    b.HasBaseType("HelpHome.Entities.Offer");

                    b.Property<int>("WindowsCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("WindowsCleaning");
                });

            modelBuilder.Entity("HelpHome.Entities.Seeker", b =>
                {
                    b.HasBaseType("HelpHome.Entities.User");

                    b.HasDiscriminator().HasValue("Seeker");
                });

            modelBuilder.Entity("HelpHome.Entities.Offer", b =>
                {
                    b.HasOne("HelpHome.Entities.User", "User")
                        .WithMany("offers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HelpHome.Entities.User", b =>
                {
                    b.Navigation("offers");
                });
#pragma warning restore 612, 618
        }
    }
}
