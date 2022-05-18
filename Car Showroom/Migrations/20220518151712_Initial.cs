using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Showroom.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    country_code = table.Column<string>(unicode: false, maxLength: 7, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    district = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    street = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    apartment_number = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    postal_code = table.Column<string>(unicode: false, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    production_year = table.Column<DateTime>(type: "date", nullable: true),
                    weight = table.Column<int>(nullable: true),
                    used = table.Column<bool>(nullable: true),
                    crashed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAILS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENGINE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(unicode: false, maxLength: 100, nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    size = table.Column<int>(nullable: true),
                    power = table.Column<int>(nullable: true),
                    price = table.Column<int>(nullable: true),
                    fuel_consumption = table.Column<double>(nullable: true),
                    energy_consumption = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENGINE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MODEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    type = table.Column<int>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OPTION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRIM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRIM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ADDRESS_ID = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pesel = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    birth_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.ID);
                    table.ForeignKey(
                        name: "ApplicationUser_ADDRESS_FK",
                        column: x => x.ADDRESS_ID,
                        principalTable: "ADDRESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEALER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS_ID = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    max_cars_number = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEALER", x => x.ID);
                    table.ForeignKey(
                        name: "DEALER_ADDRESS_FK",
                        column: x => x.ADDRESS_ID,
                        principalTable: "ADDRESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "MODELS_ENGINES",
                columns: table => new
                {
                    ENGINE_ID = table.Column<int>(nullable: false),
                    MODEL_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MODELS_ENGINES_PK", x => new { x.ENGINE_ID, x.MODEL_ID });
                    table.ForeignKey(
                        name: "MODELS_ENGINES_ENGINE_FK",
                        column: x => x.ENGINE_ID,
                        principalTable: "ENGINE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MODELS_ENGINES_MODEL_FK",
                        column: x => x.MODEL_ID,
                        principalTable: "MODEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MODELS_TRIMS",
                columns: table => new
                {
                    MODEL_ID = table.Column<int>(nullable: false),
                    TRIM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MODELS_TRIMS_PK", x => new { x.MODEL_ID, x.TRIM_ID });
                    table.ForeignKey(
                        name: "MODELS_TRIMS_MODEL_FK",
                        column: x => x.MODEL_ID,
                        principalTable: "MODEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MODELS_TRIMS_TRIM_FK",
                        column: x => x.TRIM_ID,
                        principalTable: "TRIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRIMS_OPTIONS",
                columns: table => new
                {
                    OPTION_ID = table.Column<int>(nullable: false),
                    TRIM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TRIMS_OPTIONS_PK", x => new { x.OPTION_ID, x.TRIM_ID });
                    table.ForeignKey(
                        name: "TRIMS_OPTIONS_OPTION_FK",
                        column: x => x.OPTION_ID,
                        principalTable: "OPTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "TRIMS_OPTIONS_TRIM_FK",
                        column: x => x.TRIM_ID,
                        principalTable: "TRIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUser_ID = table.Column<string>(maxLength: 450, nullable: false),
                    customer_type = table.Column<int>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID);
                    table.ForeignKey(
                        name: "CUSTOMER_ApplicationUser_FK",
                        column: x => x.ApplicationUser_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUser_ID = table.Column<string>(maxLength: 450, nullable: false),
                    DEALER_ID = table.Column<int>(nullable: false),
                    contract_type = table.Column<int>(unicode: false, maxLength: 100, nullable: false),
                    employment_date = table.Column<DateTime>(type: "date", nullable: true),
                    job_position = table.Column<int>(unicode: false, maxLength: 100, nullable: false),
                    manager_id = table.Column<int>(nullable: true),
                    salary = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                    table.ForeignKey(
                        name: "EMPLOYEE_ApplicationUser_FK",
                        column: x => x.ApplicationUser_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EMPLOYEE_DEALER_FK",
                        column: x => x.DEALER_ID,
                        principalTable: "DEALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(nullable: false),
                    dealer_EMPLOYEE_ID = table.Column<int>(nullable: true),
                    service_EMPLOYEE_ID = table.Column<int>(nullable: true),
                    status = table.Column<int>(unicode: false, maxLength: 100, nullable: false),
                    price = table.Column<double>(nullable: true),
                    discount = table.Column<double>(nullable: true),
                    payment_type = table.Column<int>(unicode: false, maxLength: 100, nullable: false),
                    submission_date = table.Column<DateTime>(type: "date", nullable: true),
                    finalization_date = table.Column<DateTime>(type: "date", nullable: true),
                    shipment_type = table.Column<int>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                    table.ForeignKey(
                        name: "ORDER_CUSTOMER_FK",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ORDER_dealer_EMPLOYEE_FK",
                        column: x => x.dealer_EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ORDER_service_EMPLOYEE_FK",
                        column: x => x.service_EMPLOYEE_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAR",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DETAILS_ID = table.Column<int>(nullable: false),
                    DEALER_ID = table.Column<int>(nullable: true),
                    ORDER_ID = table.Column<int>(nullable: true),
                    MODEL_ID = table.Column<int>(nullable: false),
                    TRIM_ID = table.Column<int>(nullable: false),
                    ENGINE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.ID);
                    table.ForeignKey(
                        name: "CAR_DEALER_FK",
                        column: x => x.DEALER_ID,
                        principalTable: "DEALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CAR_DETAILS_FK",
                        column: x => x.DETAILS_ID,
                        principalTable: "DETAILS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CAR_ENGINE_FK",
                        column: x => x.ENGINE_ID,
                        principalTable: "ENGINE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CAR_MODEL_FK",
                        column: x => x.MODEL_ID,
                        principalTable: "MODEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CAR_ORDER_FK",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CAR_TRIM_FK",
                        column: x => x.TRIM_ID,
                        principalTable: "TRIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS_OPTIONS",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false),
                    OPTION_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ORDERS_OPTIONS_PK", x => new { x.OPTION_ID, x.ORDER_ID });
                    table.ForeignKey(
                        name: "ORDERS_OPTIONS_OPTION_FK",
                        column: x => x.OPTION_ID,
                        principalTable: "OPTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ORDERS_OPTIONS_ORDER_FK",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AspNetUsers_ADDRESS_ID",
                table: "AspNetUsers",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_DEALER_ID",
                table: "CAR",
                column: "DEALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_DETAILS_ID",
                table: "CAR",
                column: "DETAILS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_ENGINE_ID",
                table: "CAR",
                column: "ENGINE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_MODEL_ID",
                table: "CAR",
                column: "MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_ORDER_ID",
                table: "CAR",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_TRIM_ID",
                table: "CAR",
                column: "TRIM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ApplicationUser_ID",
                table: "CUSTOMER",
                column: "ApplicationUser_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEALER_ADDRESS_ID",
                table: "DEALER",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ApplicationUser_ID",
                table: "EMPLOYEE",
                column: "ApplicationUser_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DEALER_ID",
                table: "EMPLOYEE",
                column: "DEALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MODELS_ENGINES_MODEL_ID",
                table: "MODELS_ENGINES",
                column: "MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MODELS_TRIMS_TRIM_ID",
                table: "MODELS_TRIMS",
                column: "TRIM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_CUSTOMER_ID",
                table: "ORDER",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_dealer_EMPLOYEE_ID",
                table: "ORDER",
                column: "dealer_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_service_EMPLOYEE_ID",
                table: "ORDER",
                column: "service_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_OPTIONS_ORDER_ID",
                table: "ORDERS_OPTIONS",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRIMS_OPTIONS_TRIM_ID",
                table: "TRIMS_OPTIONS",
                column: "TRIM_ID");
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
                name: "CAR");

            migrationBuilder.DropTable(
                name: "MODELS_ENGINES");

            migrationBuilder.DropTable(
                name: "MODELS_TRIMS");

            migrationBuilder.DropTable(
                name: "ORDERS_OPTIONS");

            migrationBuilder.DropTable(
                name: "TRIMS_OPTIONS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DETAILS");

            migrationBuilder.DropTable(
                name: "ENGINE");

            migrationBuilder.DropTable(
                name: "MODEL");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "OPTION");

            migrationBuilder.DropTable(
                name: "TRIM");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DEALER");

            migrationBuilder.DropTable(
                name: "ADDRESS");
        }
    }
}
