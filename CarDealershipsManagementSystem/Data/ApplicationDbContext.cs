using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarDealershipsManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipsManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Adresses { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Dealership> Dealerships { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Engine> Engines { get; set; } = null!;
        public virtual DbSet<Equipment> Equipments { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressCountryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressStreet)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressApartmentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.AddressPostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarProductionYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CarWeight)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CarUsed)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CarCrashed)
                    .IsUnicode(false);

                entity.HasOne(p => p.Dealership)
                    .WithMany(d => d.Cars)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.Engine)
                    .WithMany(d => d.Cars)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.Model)
                    .WithMany(d => d.Cars)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.Equipment)
                    .WithMany(d => d.Cars)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.Order)
                    .WithMany(d => d.Cars)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasMany(d => d.Orders)
                    .WithOne(p => p.Customer)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Dealership>(entity =>
            {
                entity.ToTable("Dealership");

                entity.Property(e => e.DealershipName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.DealershipMaxCarsNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Employees)
                    .WithOne(p => p.Dealership)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeContractType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeJobPosition)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeSalary)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeStartDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeFinishDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dealership)
                    .WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.DealershipOrders)
                    .WithOne(p => p.DealershipEmployee)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.ServiceOrders)
                    .WithOne(p => p.ServiceEmployee)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("Engine");

                entity.Property(e => e.EngineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EngineType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Models)
                    .WithMany(p => p.Engines)
                    .UsingEntity<Dictionary<string, object>>(
                        "ModelEngine",
                        l => l.HasOne<Model>().WithMany().HasForeignKey("ModelId").HasConstraintName("ModelEngine_Model_FK"),
                        r => r.HasOne<Engine>().WithMany().HasForeignKey("EngineId").HasConstraintName("ModelEngine_Engine_FK"),
                        j =>
                        {

                            j.HasKey("ModelId", "EngineId").HasName("ModelEngine_PK");

                            j.ToTable("ModelEngine");
                        });
            });

            modelBuilder.Entity<Equipment>(entity =>
            {

                entity.ToTable("Equipment");

                entity.Property(e => e.EquipmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Options)
                    .WithMany(p => p.Equipments)
                    .UsingEntity<Dictionary<string, object>>(
                        "EquipmentOption",
                        l => l.HasOne<Option>().WithMany().HasForeignKey("OptionId").HasConstraintName("EquipmentOption_Option_FK"),
                        r => r.HasOne<Equipment>().WithMany().HasForeignKey("EquipmentId").HasConstraintName("EquipmentOption_Equipment_FK"),
                        j =>
                        {
                            j.HasKey("EquipmentId", "OptionId").HasName("EquipmentOption_PK");

                            j.ToTable("EquipmentOption");
                        });
                entity.HasMany(d => d.Models)
                    .WithMany(p => p.Equipments)
                    .UsingEntity<Dictionary<string, object>>(
                        "ModelEquipment",
                        l => l.HasOne<Model>().WithMany().HasForeignKey("ModelId").HasConstraintName("ModelEquipment_Model_FK"),
                        r => r.HasOne<Equipment>().WithMany().HasForeignKey("EquipmentId").HasConstraintName("ModelEquipment_Equipment_FK"),
                        j =>
                        {
                            j.HasKey("ModelId", "EquipmentId").HasName("ModelEquipment_PK");

                            j.ToTable("ModelEquipment");
                        });
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.ModelImagePath)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ModelType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasMany(d => d.Engines)
                    .WithMany(p => p.Models)
                    .UsingEntity<Dictionary<string, object>>(
                        "ModelEngine",
                        l => l.HasOne<Engine>().WithMany().HasForeignKey("EngineId").HasConstraintName("ModelEngine_Engine_FK"),
                        r => r.HasOne<Model>().WithMany().HasForeignKey("ModelId").HasConstraintName("ModelEngine_Model_FK"),
                        j =>
                        {
                            j.HasKey("ModelId", "EngineId").HasName("ModelEngine_PK");

                            j.ToTable("ModelEngine");
                        });

                entity.HasMany(d => d.Equipments)
                    .WithMany(p => p.Models)
                    .UsingEntity<Dictionary<string, object>>(
                        "ModelEquipment",
                        l => l.HasOne<Equipment>().WithMany().HasForeignKey("EquipmentId").HasConstraintName("ModelEquipment_Equipment_FK"),
                        r => r.HasOne<Model>().WithMany().HasForeignKey("ModelId").HasConstraintName("ModelEquipment_Model_FK"),
                        j =>
                        {
                            j.HasKey("ModelId", "EquipmentId").HasName("ModelEquipment_PK");

                            j.ToTable("ModelEquipment");
                        });
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option");

                entity.Property(e => e.OptionDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.OptionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Equipments)
                    .WithMany(p => p.Options)
                    .UsingEntity<Dictionary<string, object>>(
                        "EquipmentOption",
                        l => l.HasOne<Equipment>().WithMany().HasForeignKey("EquipmentId").HasConstraintName("EquipmentOption_Equipment_FK"),
                        r => r.HasOne<Option>().WithMany().HasForeignKey("OptionId").HasConstraintName("EquipmentOption_Option_FK"),
                        j =>
                        {
                            j.HasKey("EquipmentId", "OptionId").HasName("EquipmentOption_PK");

                            j.ToTable("EquipmentOption");
                        });

                entity.HasMany(d => d.Orders)
                    .WithMany(p => p.Options)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderOption",
                        l => l.HasOne<Order>().WithMany().HasForeignKey("OrderId").HasConstraintName("OrderOption_Equipment_FK"),
                        r => r.HasOne<Option>().WithMany().HasForeignKey("OptionId").HasConstraintName("OrderOption_Option_FK"),
                        j =>
                        {
                            j.HasKey("OrderId", "OptionId").HasName("OrderOption_PK");

                            j.ToTable("OrderOption");
                        });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.OrderPaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderShipmentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderSubmissionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderFinalizationDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderPrice)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderDiscount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Options)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderOption",
                        l => l.HasOne<Option>().WithMany().HasForeignKey("OptionId").HasConstraintName("OrderOption_Option_FK"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").HasConstraintName("OrderOption_Order_FK"),
                        j =>
                        {
                            j.HasKey("OrderId", "OptionId").HasName("OrderOption_PK");

                            j.ToTable("OrderOption");
                        });

                entity.HasMany(d => d.Cars)
                    .WithOne(p => p.Order);
                entity.HasOne(p => p.DealershipEmployee)
                    .WithMany(d => d.DealershipOrders)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.ServiceEmployee)
                    .WithMany(d => d.ServiceOrders)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.Customer)
                    .WithMany(d => d.Orders)
                    .OnDelete(DeleteBehavior.NoAction);

            });
        }
    }
}