using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

public class AutoLandDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }

    public DbSet<Rent> Rents { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<Insurance> Insurances { get; set; }

    public AutoLandDbContext()
    {
        //Database.EnsureDeleted();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rent>()
      .HasOne(r => r.User)
      .WithMany(u => u.Rents)
      .HasForeignKey(r => r.UserId)  
      .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rent>()
            .HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.CarId)  
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Review>()
        .HasOne(r => r.Sender)
        .WithMany(u => u.RewiewsReceived)
        .HasForeignKey(r => r.SenderId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Reciever)
            .WithMany()
            .HasForeignKey(r => r.RecieverId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Марія Петрова",
                Email = "maria@example.com",
                Type = "Орендар",
                Raiting = 4.8,
                Licence = "Є"
            },
            new User
            {
                Id = 2,
                Name = "Іван Іваненко",
                Email = "ivan@example.com",
                Type = "Власник",
                Raiting = 5.0,
                Licence = "Є"
            }
        );
        modelBuilder.Entity<Car>().HasData(
        new Car
        {
            Id = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2020,
            BodyType = "Седан",
            Mileage = 45000,
            FuelType = "Бензин",
            NumberPlate = "AA1234AA",
            UserId = 2,
            Price = 20,
            Status = "Доступна",
        },
        new Car
        {
            Id = 2,
            Brand = "Volkswagen",
            Model = "Passat",
            Year = 2019,
            BodyType = "Універсал",
            Mileage = 62000,
            FuelType = "Дизель",
            NumberPlate = "BB5678BB",
            UserId = 2,
            Price = 60,
            Status = "Доступна",
        },
        new Car
        {
            Id = 3,
            Brand = "Tesla",
            Model = "Model 3",
            Year = 2022,
            BodyType = "Седан",
            Mileage = 15000,
            FuelType = "Електро",
            NumberPlate = "CC9012CC",
            UserId = 2,
            Price = 40,
            Status = "Доступна",
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string configString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AutoLandDB;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        optionsBuilder.UseSqlServer(configString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
    }

}
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public string? Type { get; set; }

    public double? Raiting { get; set; }

    public string? Licence { get; set; }


    public ICollection<Car>? OwnedCars { get; set; } = new List<Car>();


    public ICollection<Rent>? Rents { get; set; } = new List<Rent>();

    public ICollection<Review>? RewiewsReceived { get; set; } = new List<Review>();

}

public class Car
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }

    public int? Year { get; set; }


    public string? BodyType { get; set; }

    public decimal? Mileage { get; set; }

    public string? FuelType { get; set; }

    public string? NumberPlate { get; set; }

    public int?  UserId { get; set; }
    public User? User { get; set; }

    public int? Price { get; set; }
    public string? Status { get; set; }



    public ICollection<Review>? Reviews { get; set; } = new List<Review>();


}

public class Rent
{
    public int Id { get; set; }

    public int? CarId { get; set; }
    public Car? Car { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }

    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }
}

public class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public decimal? Amount { get; set; }

    public string? Type { get; set; }

    public DateTime Date { get; set; }

}

public class Review
{

    public int Id { get; set; }
    public int SenderId { get; set; }
    public User? Sender { get; set; }

    public int? RecieverId { get; set; }
    public User? Reciever { get; set; }
    public int? CarId { get; set; }

    public Car? Car { get; set; } 


    public double? Raiting { get; set; }

    public string? Comment { get; set; }

}

public class Insurance
{
    public int Id { get; set; }
    public int? CarId { get; set; }
    public Car? Car { get; set; }
    public string? Type { get; set; }

    public int? Period { get; set; }

    public string? CompanyName { get; set; }
}