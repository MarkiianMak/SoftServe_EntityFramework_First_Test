﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace appka.Migrations
{
    [DbContext(typeof(AutoLandDbContext))]
    [Migration("20250416153052_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyType = "Седан",
                            Brand = "Toyota",
                            FuelType = "Бензин",
                            Mileage = 45000m,
                            Model = "Corolla",
                            NumberPlate = "AA1234AA",
                            Status = "Доступна",
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            BodyType = "Універсал",
                            Brand = "Volkswagen",
                            FuelType = "Дизель",
                            Mileage = 62000m,
                            Model = "Passat",
                            NumberPlate = "BB5678BB",
                            Status = "Доступна",
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            BodyType = "Седан",
                            Brand = "Tesla",
                            FuelType = "Електро",
                            Mileage = 15000m,
                            Model = "Model 3",
                            NumberPlate = "CC9012CC",
                            Status = "Доступна",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Rewiew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Raiting")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rewiews");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Licence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raiting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "maria@example.com",
                            Licence = "AA111111",
                            Name = "Марія Петрова",
                            Raiting = "4.8",
                            Type = "Клієнт"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ivan@example.com",
                            Licence = "BB222222",
                            Name = "Іван Іваненко",
                            Raiting = "5.0",
                            Type = "Клієнт"
                        });
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Insurance", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Payment", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rent", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rewiew", b =>
                {
                    b.HasOne("Car", "Reciever")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Sender")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });
#pragma warning restore 612, 618
        }
    }
}
