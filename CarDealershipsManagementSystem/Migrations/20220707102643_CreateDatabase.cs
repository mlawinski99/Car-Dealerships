using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipsManagementSystem.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressCountryCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressDistrict = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressStreet = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressApartmentNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressPostalCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EngineType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EngineDisplacement = table.Column<int>(type: "int", nullable: true),
                    EnginePower = table.Column<int>(type: "int", nullable: true),
                    EnigneFuelConsumption = table.Column<float>(type: "real", nullable: true),
                    EnginePowerConsumption = table.Column<float>(type: "real", nullable: true),
                    EnginePrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EquipmentPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModelType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModelImagePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ModelPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OptionDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OptionPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dealership",
                columns: table => new
                {
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealershipName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DealershipMaxCarsNumber = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealership", x => x.DealershipId);
                    table.ForeignKey(
                        name: "FK_Dealership_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelEngine",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ModelEngine_PK", x => new { x.ModelId, x.EngineId });
                    table.ForeignKey(
                        name: "ModelEngine_Engine_FK",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ModelEngine_Model_FK",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelEquipment",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ModelEquipment_PK", x => new { x.ModelId, x.EquipmentId });
                    table.ForeignKey(
                        name: "ModelEquipment_Equipment_FK",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ModelEquipment_Model_FK",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentOption",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EquipmentOption_PK", x => new { x.EquipmentId, x.OptionId });
                    table.ForeignKey(
                        name: "EquipmentOption_Equipment_FK",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "EquipmentOption_Option_FK",
                        column: x => x.OptionId,
                        principalTable: "Option",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeContractType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmployeeJobPosition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmployeeSalary = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: true),
                    EmployeeStartDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: true),
                    EmployeeFinishDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DealershipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Dealership_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealership",
                        principalColumn: "DealershipId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OrderPaymentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderShipmentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderSubmissionDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: true),
                    OrderFinalizationDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: true),
                    OrderPrice = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: true),
                    OrderDiscount = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DealershipEmployeeEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ServiceEmployeeEmployeeId = table.Column<int>(type: "int", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Order_Dealership_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealership",
                        principalColumn: "DealershipId");
                    table.ForeignKey(
                        name: "FK_Order_Employee_DealershipEmployeeEmployeeId",
                        column: x => x.DealershipEmployeeEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Order_Employee_ServiceEmployeeEmployeeId",
                        column: x => x.ServiceEmployeeEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarProductionYear = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: true),
                    CarWeight = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: true),
                    CarUsed = table.Column<bool>(type: "bit", unicode: false, maxLength: 50, nullable: true),
                    CarCrashed = table.Column<bool>(type: "bit", unicode: false, nullable: true),
                    DealershipId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_Dealership_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealership",
                        principalColumn: "DealershipId");
                    table.ForeignKey(
                        name: "FK_Car_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId");
                    table.ForeignKey(
                        name: "FK_Car_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId");
                    table.ForeignKey(
                        name: "FK_Car_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId");
                    table.ForeignKey(
                        name: "FK_Car_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderOption",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderOption_PK", x => new { x.OrderId, x.OptionId });
                    table.ForeignKey(
                        name: "OrderOption_Option_FK",
                        column: x => x.OptionId,
                        principalTable: "Option",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "OrderOption_Order_FK",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Car_DealershipId",
                table: "Car",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                table: "Car",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EquipmentId",
                table: "Car",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_OrderId",
                table: "Car",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ApplicationUserId",
                table: "Customer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealership_AddressId",
                table: "Dealership",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DealershipId",
                table: "Employee",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentOption_OptionId",
                table: "EquipmentOption",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelEngine_EngineId",
                table: "ModelEngine",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelEquipment_EquipmentId",
                table: "ModelEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DealershipEmployeeEmployeeId",
                table: "Order",
                column: "DealershipEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DealershipId",
                table: "Order",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ServiceEmployeeEmployeeId",
                table: "Order",
                column: "ServiceEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOption_OptionId",
                table: "OrderOption",
                column: "OptionId");


            migrationBuilder.Sql(File.ReadAllText("FillDatabase.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "EquipmentOption");

            migrationBuilder.DropTable(
                name: "ModelEngine");

            migrationBuilder.DropTable(
                name: "ModelEquipment");

            migrationBuilder.DropTable(
                name: "OrderOption");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dealership");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
