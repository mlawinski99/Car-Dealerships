﻿// <auto-generated />
using System;
using Car_Showroom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Car_Showroom.Migrations
{
    [DbContext(typeof(CarDealershipsContext))]
    partial class CarDealershipsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Car_Showroom.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnName("apartment_number")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CountryCode")
                        .HasColumnName("country_code")
                        .HasColumnType("varchar(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("District")
                        .HasColumnName("district")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PostalCode")
                        .HasColumnName("postal_code")
                        .HasColumnType("varchar(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ADDRESS");
                });

            modelBuilder.Entity("Car_Showroom.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnName("ADDRESS_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnName("pesel")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Car_Showroom.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DealerId")
                        .HasColumnName("DEALER_ID")
                        .HasColumnType("int");

                    b.Property<int>("DetailsId")
                        .HasColumnName("DETAILS_ID")
                        .HasColumnType("int");

                    b.Property<int>("EngineId")
                        .HasColumnName("ENGINE_ID")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnName("MODEL_ID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnName("ORDER_ID")
                        .HasColumnType("int");

                    b.Property<int>("TrimId")
                        .HasColumnName("TRIM_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("DetailsId");

                    b.HasIndex("EngineId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OrderId");

                    b.HasIndex("TrimId");

                    b.ToTable("CAR");
                });

            modelBuilder.Entity("Car_Showroom.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnName("ApplicationUser_ID")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<int>("CustomerType")
                        .HasColumnName("customer_type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("Car_Showroom.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnName("ADDRESS_ID")
                        .HasColumnType("int");

                    b.Property<int?>("MaxCarsNumber")
                        .HasColumnName("max_cars_number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("DEALER");
                });

            modelBuilder.Entity("Car_Showroom.Models.Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Crashed")
                        .HasColumnName("crashed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ProductionYear")
                        .HasColumnName("production_year")
                        .HasColumnType("date");

                    b.Property<bool?>("Used")
                        .HasColumnName("used")
                        .HasColumnType("bit");

                    b.Property<int?>("Weight")
                        .HasColumnName("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DETAILS");
                });

            modelBuilder.Entity("Car_Showroom.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnName("ApplicationUser_ID")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<int>("ContractType")
                        .HasColumnName("contract_type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("DealerId")
                        .HasColumnName("DEALER_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EmploymentDate")
                        .HasColumnName("employment_date")
                        .HasColumnType("date");

                    b.Property<int>("JobPosition")
                        .HasColumnName("job_position")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("manager_id")
                        .HasColumnType("int");

                    b.Property<double?>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DealerId");

                    b.ToTable("EMPLOYEE");
                });

            modelBuilder.Entity("Car_Showroom.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("EnergyConsumption")
                        .HasColumnName("energy_consumption")
                        .HasColumnType("float");

                    b.Property<double?>("FuelConsumption")
                        .HasColumnName("fuel_consumption")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Power")
                        .HasColumnName("power")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnName("price")
                        .HasColumnType("int");

                    b.Property<int?>("Size")
                        .HasColumnName("size")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ENGINE");
                });

            modelBuilder.Entity("Car_Showroom.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("MODEL");
                });

            modelBuilder.Entity("Car_Showroom.Models.ModelsEngines", b =>
                {
                    b.Property<int>("EngineId")
                        .HasColumnName("ENGINE_ID")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnName("MODEL_ID")
                        .HasColumnType("int");

                    b.HasKey("EngineId", "ModelId")
                        .HasName("MODELS_ENGINES_PK");

                    b.HasIndex("ModelId");

                    b.ToTable("MODELS_ENGINES");
                });

            modelBuilder.Entity("Car_Showroom.Models.ModelsTrims", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnName("MODEL_ID")
                        .HasColumnType("int");

                    b.Property<int>("TrimId")
                        .HasColumnName("TRIM_ID")
                        .HasColumnType("int");

                    b.HasKey("ModelId", "TrimId")
                        .HasName("MODELS_TRIMS_PK");

                    b.HasIndex("TrimId");

                    b.ToTable("MODELS_TRIMS");
                });

            modelBuilder.Entity("Car_Showroom.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("OPTION");
                });

            modelBuilder.Entity("Car_Showroom.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnType("int");

                    b.Property<int?>("DealerEmployeeId")
                        .HasColumnName("dealer_EMPLOYEE_ID")
                        .HasColumnType("int");

                    b.Property<double?>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("FinalizationDate")
                        .HasColumnName("finalization_date")
                        .HasColumnType("date");

                    b.Property<int>("PaymentType")
                        .HasColumnName("payment_type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<double?>("Price")
                        .HasColumnName("price")
                        .HasColumnType("float");

                    b.Property<int?>("ServiceEmployeeId")
                        .HasColumnName("service_EMPLOYEE_ID")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentType")
                        .HasColumnName("shipment_type")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnName("submission_date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DealerEmployeeId");

                    b.HasIndex("ServiceEmployeeId");

                    b.ToTable("ORDER");
                });

            modelBuilder.Entity("Car_Showroom.Models.OrdersOptions", b =>
                {
                    b.Property<int>("OptionId")
                        .HasColumnName("OPTION_ID")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnName("ORDER_ID")
                        .HasColumnType("int");

                    b.HasKey("OptionId", "OrderId")
                        .HasName("ORDERS_OPTIONS_PK");

                    b.HasIndex("OrderId");

                    b.ToTable("ORDERS_OPTIONS");
                });

            modelBuilder.Entity("Car_Showroom.Models.Trim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TRIM");
                });

            modelBuilder.Entity("Car_Showroom.Models.TrimsOptions", b =>
                {
                    b.Property<int>("OptionId")
                        .HasColumnName("OPTION_ID")
                        .HasColumnType("int");

                    b.Property<int>("TrimId")
                        .HasColumnName("TRIM_ID")
                        .HasColumnType("int");

                    b.HasKey("OptionId", "TrimId")
                        .HasName("TRIMS_OPTIONS_PK");

                    b.HasIndex("TrimId");

                    b.ToTable("TRIMS_OPTIONS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Car_Showroom.Models.ApplicationUser", b =>
                {
                    b.HasOne("Car_Showroom.Models.Address", "Address")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("ApplicationUser_ADDRESS_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.Car", b =>
                {
                    b.HasOne("Car_Showroom.Models.Dealer", "Dealer")
                        .WithMany("Car")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("CAR_DEALER_FK");

                    b.HasOne("Car_Showroom.Models.Details", "Details")
                        .WithMany("Car")
                        .HasForeignKey("DetailsId")
                        .HasConstraintName("CAR_DETAILS_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Engine", "Engine")
                        .WithMany("Car")
                        .HasForeignKey("EngineId")
                        .HasConstraintName("CAR_ENGINE_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Model", "Model")
                        .WithMany("Car")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("CAR_MODEL_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Order", "Order")
                        .WithMany("Car")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("CAR_ORDER_FK");

                    b.HasOne("Car_Showroom.Models.Trim", "Trim")
                        .WithMany("Car")
                        .HasForeignKey("TrimId")
                        .HasConstraintName("CAR_TRIM_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.Customer", b =>
                {
                    b.HasOne("Car_Showroom.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Customer")
                        .HasForeignKey("ApplicationUserId")
                        .HasConstraintName("CUSTOMER_ApplicationUser_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.Dealer", b =>
                {
                    b.HasOne("Car_Showroom.Models.Address", "Address")
                        .WithMany("Dealer")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("DEALER_ADDRESS_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.Employee", b =>
                {
                    b.HasOne("Car_Showroom.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Employee")
                        .HasForeignKey("ApplicationUserId")
                        .HasConstraintName("EMPLOYEE_ApplicationUser_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Dealer", "Dealer")
                        .WithMany("Employee")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("EMPLOYEE_DEALER_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.ModelsEngines", b =>
                {
                    b.HasOne("Car_Showroom.Models.Engine", "Engine")
                        .WithMany("ModelsEngines")
                        .HasForeignKey("EngineId")
                        .HasConstraintName("MODELS_ENGINES_ENGINE_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Model", "Model")
                        .WithMany("ModelsEngines")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("MODELS_ENGINES_MODEL_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.ModelsTrims", b =>
                {
                    b.HasOne("Car_Showroom.Models.Model", "Model")
                        .WithMany("ModelsTrims")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("MODELS_TRIMS_MODEL_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Trim", "Trim")
                        .WithMany("ModelsTrims")
                        .HasForeignKey("TrimId")
                        .HasConstraintName("MODELS_TRIMS_TRIM_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.Order", b =>
                {
                    b.HasOne("Car_Showroom.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("ORDER_CUSTOMER_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Employee", "DealerEmployee")
                        .WithMany("OrderDealerEmployee")
                        .HasForeignKey("DealerEmployeeId")
                        .HasConstraintName("ORDER_dealer_EMPLOYEE_FK");

                    b.HasOne("Car_Showroom.Models.Employee", "ServiceEmployee")
                        .WithMany("OrderServiceEmployee")
                        .HasForeignKey("ServiceEmployeeId")
                        .HasConstraintName("ORDER_service_EMPLOYEE_FK");
                });

            modelBuilder.Entity("Car_Showroom.Models.OrdersOptions", b =>
                {
                    b.HasOne("Car_Showroom.Models.Option", "Option")
                        .WithMany("OrdersOptions")
                        .HasForeignKey("OptionId")
                        .HasConstraintName("ORDERS_OPTIONS_OPTION_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Order", "Order")
                        .WithMany("OrdersOptions")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("ORDERS_OPTIONS_ORDER_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_Showroom.Models.TrimsOptions", b =>
                {
                    b.HasOne("Car_Showroom.Models.Option", "Option")
                        .WithMany("TrimsOptions")
                        .HasForeignKey("OptionId")
                        .HasConstraintName("TRIMS_OPTIONS_OPTION_FK")
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.Trim", "Trim")
                        .WithMany("TrimsOptions")
                        .HasForeignKey("TrimId")
                        .HasConstraintName("TRIMS_OPTIONS_TRIM_FK")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Car_Showroom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Car_Showroom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_Showroom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Car_Showroom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
