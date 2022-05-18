using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class CarDealershipsContext : IdentityDbContext<ApplicationUser>
    {
        public CarDealershipsContext()
        {
        }

        public CarDealershipsContext(DbContextOptions<CarDealershipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<ModelsEngines> ModelsEngines { get; set; }
        public virtual DbSet<ModelsTrims> ModelsTrims { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrdersOptions> OrdersOptions { get; set; }
        public virtual DbSet<Trim> Trim { get; set; }
        public virtual DbSet<TrimsOptions> TrimsOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=CarDealerships;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApartmentNumber)
                    .HasColumnName("apartment_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("country_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pesel)
                    .HasColumnName("pesel")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ApplicationUser)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ApplicationUser_ADDRESS_FK");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CAR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DealerId).HasColumnName("DEALER_ID");

                entity.Property(e => e.DetailsId).HasColumnName("DETAILS_ID");

                entity.Property(e => e.EngineId).HasColumnName("ENGINE_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.TrimId).HasColumnName("TRIM_ID");

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.DealerId)
                    .HasConstraintName("CAR_DEALER_FK");

                entity.HasOne(d => d.Details)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.DetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAR_DETAILS_FK");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAR_ENGINE_FK");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAR_MODEL_FK");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("CAR_ORDER_FK");

                entity.HasOne(d => d.Trim)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.TrimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAR_TRIM_FK");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationUserId)
                    .IsRequired()
                    .HasColumnName("ApplicationUser_ID")
                    .HasMaxLength(450);

                entity.Property(e => e.CustomerType)
                    .HasColumnName("customer_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CUSTOMER_ApplicationUser_FK");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.ToTable("DEALER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");

                entity.Property(e => e.MaxCarsNumber).HasColumnName("max_cars_number");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Dealer)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DEALER_ADDRESS_FK");
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.ToTable("DETAILS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Crashed).HasColumnName("crashed");

              
                entity.Property(e => e.ProductionYear)
                    .HasColumnName("production_year")
                    .HasColumnType("date");

                entity.Property(e => e.Used).HasColumnName("used");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationUserId)
                    .IsRequired()
                    .HasColumnName("ApplicationUser_ID")
                    .HasMaxLength(450);

                entity.Property(e => e.ContractType)
                    .HasColumnName("contract_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DealerId).HasColumnName("DEALER_ID");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnName("employment_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobPosition)
                    .HasColumnName("job_position")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYEE_ApplicationUser_FK");

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DealerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYEE_DEALER_FK");
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("ENGINE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnergyConsumption).HasColumnName("energy_consumption");

                entity.Property(e => e.FuelConsumption).HasColumnName("fuel_consumption");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("MODEL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModelsEngines>(entity =>
            {
                entity.HasKey(e => new { e.EngineId, e.ModelId })
                    .HasName("MODELS_ENGINES_PK");

                entity.ToTable("MODELS_ENGINES");

                entity.Property(e => e.EngineId).HasColumnName("ENGINE_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.ModelsEngines)
                    .HasForeignKey(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODELS_ENGINES_ENGINE_FK");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelsEngines)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODELS_ENGINES_MODEL_FK");
            });

            modelBuilder.Entity<ModelsTrims>(entity =>
            {
                entity.HasKey(e => new { e.ModelId, e.TrimId })
                    .HasName("MODELS_TRIMS_PK");

                entity.ToTable("MODELS_TRIMS");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.TrimId).HasColumnName("TRIM_ID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelsTrims)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODELS_TRIMS_MODEL_FK");

                entity.HasOne(d => d.Trim)
                    .WithMany(p => p.ModelsTrims)
                    .HasForeignKey(d => d.TrimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODELS_TRIMS_TRIM_FK");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("OPTION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DealerEmployeeId).HasColumnName("dealer_EMPLOYEE_ID");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FinalizationDate)
                    .HasColumnName("finalization_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ServiceEmployeeId).HasColumnName("service_EMPLOYEE_ID");

                entity.Property(e => e.ShipmentType)
                    .HasColumnName("shipment_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionDate)
                    .HasColumnName("submission_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDER_CUSTOMER_FK");

                entity.HasOne(d => d.DealerEmployee)
                    .WithMany(p => p.OrderDealerEmployee)
                    .HasForeignKey(d => d.DealerEmployeeId)
                    .HasConstraintName("ORDER_dealer_EMPLOYEE_FK");

                entity.HasOne(d => d.ServiceEmployee)
                    .WithMany(p => p.OrderServiceEmployee)
                    .HasForeignKey(d => d.ServiceEmployeeId)
                    .HasConstraintName("ORDER_service_EMPLOYEE_FK");
            });

            modelBuilder.Entity<OrdersOptions>(entity =>
            {
                entity.HasKey(e => new { e.OptionId, e.OrderId })
                    .HasName("ORDERS_OPTIONS_PK");

                entity.ToTable("ORDERS_OPTIONS");

                entity.Property(e => e.OptionId).HasColumnName("OPTION_ID");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.OrdersOptions)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDERS_OPTIONS_OPTION_FK");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersOptions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDERS_OPTIONS_ORDER_FK");
            });

            modelBuilder.Entity<Trim>(entity =>
            {
                entity.ToTable("TRIM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrimsOptions>(entity =>
            {
                entity.HasKey(e => new { e.OptionId, e.TrimId })
                    .HasName("TRIMS_OPTIONS_PK");

                entity.ToTable("TRIMS_OPTIONS");

                entity.Property(e => e.OptionId).HasColumnName("OPTION_ID");

                entity.Property(e => e.TrimId).HasColumnName("TRIM_ID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.TrimsOptions)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRIMS_OPTIONS_OPTION_FK");

                entity.HasOne(d => d.Trim)
                    .WithMany(p => p.TrimsOptions)
                    .HasForeignKey(d => d.TrimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRIMS_OPTIONS_TRIM_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
