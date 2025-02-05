﻿// <auto-generated />
using System;
using Lagoon.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lagoon.Infra.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241007085922_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lagoon.Domain.Entity.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VillaId");

                    b.ToTable("Amenity");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Desc = "Amenity 1 Desc",
                            Name = "Amenity 1",
                            VillaId = 1
                        },
                        new
                        {
                            ID = 2,
                            Desc = "Amenity 2 Desc",
                            Name = "Amenity 2",
                            VillaId = 2
                        },
                        new
                        {
                            ID = 3,
                            Desc = "Amenity 3 Desc",
                            Name = "Amenity 3",
                            VillaId = 3
                        });
                });

            modelBuilder.Entity("Lagoon.Domain.Entity.Villa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_Date");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Updated_Date");

                    b.HasKey("ID");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 1",
                            Occupancy = 1,
                            Price = 100.0,
                            Sqft = 1000
                        },
                        new
                        {
                            ID = 2,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 2",
                            Occupancy = 2,
                            Price = 200.0,
                            Sqft = 2000
                        },
                        new
                        {
                            ID = 3,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 3",
                            Occupancy = 3,
                            Price = 300.0,
                            Sqft = 3000
                        });
                });

            modelBuilder.Entity("Lagoon.Domain.Entity.VillaNumber", b =>
                {
                    b.Property<int>("Villa_Number")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Villa_Number");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumber");

                    b.HasData(
                        new
                        {
                            Villa_Number = 101,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 102,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 103,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 201,
                            VillaId = 2
                        },
                        new
                        {
                            Villa_Number = 202,
                            VillaId = 2
                        },
                        new
                        {
                            Villa_Number = 203,
                            VillaId = 2
                        });
                });

            modelBuilder.Entity("Lagoon.Domain.Entity.Amenity", b =>
                {
                    b.HasOne("Lagoon.Domain.Entity.Villa", "Villa")
                        .WithMany("VillaAmenity")
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("Lagoon.Domain.Entity.VillaNumber", b =>
                {
                    b.HasOne("Lagoon.Domain.Entity.Villa", "Villa")
                        .WithMany("VillaNumber")
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("Lagoon.Domain.Entity.Villa", b =>
                {
                    b.Navigation("VillaAmenity");

                    b.Navigation("VillaNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
