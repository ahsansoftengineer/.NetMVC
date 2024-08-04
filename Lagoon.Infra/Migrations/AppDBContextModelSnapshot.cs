﻿// <auto-generated />
using System;
using Lagoon.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lagoon.Infra.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lagoon.Domain.Entity.Villa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 1",
                            Price = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            ID = 2,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 2",
                            Price = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            ID = 3,
                            Desc = "No Desc",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Royal Villa 3",
                            Price = 200.0,
                            Sqft = 550
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
