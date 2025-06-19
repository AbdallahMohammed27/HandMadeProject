using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checkUserNameAndEmails",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkUserNameAndEmails", x => new { x.UserName, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MaxUse = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Discount = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(225)", maxLength: 225, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Delivery_Zones = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Pricing = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IdTax = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PusherSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PusherAppId = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PusherKey = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PusherSecret = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PusherCluster = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PusherSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Banner = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    FbLink = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    TwLink = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    InstaLink = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    ShopName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminBrands",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminBrands", x => new { x.AdminId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_AdminBrands_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminCategories",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCategories", x => new { x.AdminId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AdminCategories_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminVendorConditions",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    VendorConditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminVendorConditions", x => new { x.AdminId, x.VendorConditionsId });
                    table.ForeignKey(
                        name: "FK_AdminVendorConditions_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminVendorConditions_VendorConditions_VendorConditionsId",
                        column: x => x.VendorConditionsId,
                        principalTable: "VendorConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimAdmins_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClaimUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCoupons",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoupons", x => new { x.CouponId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCoupons_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCoupons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminVendors",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminVendors", x => new { x.AdminId, x.VendorId });
                    table.ForeignKey(
                        name: "FK_AdminVendors_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminVendors_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Seen = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClaimVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimVendors_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaypalSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyDeliveryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CurrencyName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CurrencyRate = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    SecretKey = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaypalSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaypalSettings_DeliveryCompanies_CompanyDeliveryId",
                        column: x => x.CompanyDeliveryId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaypalSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaypalSettings_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Zip = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ThumbImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ChildCategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    LongDescription = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Sku = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Price = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    OfferPrice = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true),
                    OfferStartDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    OfferEndDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ProductType = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    IsApproved = table.Column<int>(type: "int", nullable: false),
                    SeoTitle = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    SeoDescription = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ChildCategories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyDeliveryId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CurrencyName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    OrderAddress = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    OrderStatus = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryCompanies_CompanyDeliveryId",
                        column: x => x.CompanyDeliveryId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminProducts",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProducts", x => new { x.AdminId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_AdminProducts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImageGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImageGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImageGalleries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Rating = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorProducts",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorProducts", x => new { x.ProductId, x.VendorId });
                    table.ForeignKey(
                        name: "FK_VendorProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorProducts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WishList_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminOrders",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminOrders", x => new { x.AdminId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_AdminOrders_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderVendorOrders",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderVendorOrders", x => new { x.OrderId, x.VendorId });
                    table.ForeignKey(
                        name: "FK_OrderVendorOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderVendorOrders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyDeliveryId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    AmountRealCurrency = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    AmountRealCurrencyName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_DeliveryCompanies_CompanyDeliveryId",
                        column: x => x.CompanyDeliveryId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductReviewId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviewGalleries_ProductReviews_ProductReviewId",
                        column: x => x.ProductReviewId,
                        principalTable: "ProductReviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    IsDefault = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminTransactions",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    TransactionMoneyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTransactions", x => new { x.AdminId, x.TransactionMoneyId });
                    table.ForeignKey(
                        name: "FK_AdminTransactions_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminTransactions_Transactions_TransactionMoneyId",
                        column: x => x.TransactionMoneyId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorTransactions",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    transactionMoneyId = table.Column<int>(type: "int", nullable: false),
                    TranscationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorTransactions", x => new { x.VendorId, x.transactionMoneyId });
                    table.ForeignKey(
                        name: "FK_VendorTransactions_Transactions_transactionMoneyId",
                        column: x => x.transactionMoneyId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorTransactions_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Product_Variant_Item_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_ProductVariantItems_Product_Variant_Item_Id",
                        column: x => x.Product_Variant_Item_Id,
                        principalTable: "ProductVariantItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminBrands_BrandId",
                table: "AdminBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCategories_CategoryId",
                table: "AdminCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminOrders_OrderId",
                table: "AdminOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminProducts_ProductId",
                table: "AdminProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminTransactions_TransactionMoneyId",
                table: "AdminTransactions",
                column: "TransactionMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminVendorConditions_VendorConditionsId",
                table: "AdminVendorConditions",
                column: "VendorConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminVendors_VendorId",
                table: "AdminVendors",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Product_Variant_Item_Id",
                table: "CartItems",
                column: "Product_Variant_Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_VendorId",
                table: "Chats",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_SubCategoryId",
                table: "ChildCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAdmins_AdminId",
                table: "ClaimAdmins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRoles_RoleId",
                table: "ClaimRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimUsers_UserId",
                table: "ClaimUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimVendors_VendorId",
                table: "ClaimVendors",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyDeliveryId",
                table: "Orders",
                column: "CompanyDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVendorOrders_VendorId",
                table: "OrderVendorOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaypalSettings_CompanyDeliveryId",
                table: "PaypalSettings",
                column: "CompanyDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_PaypalSettings_UserId",
                table: "PaypalSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaypalSettings_VendorId",
                table: "PaypalSettings",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageGalleries_ProductId",
                table: "ProductImageGalleries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewGalleries_ProductReviewId",
                table: "ProductReviewGalleries",
                column: "ProductReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CouponId",
                table: "Products",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantItems_ProductVariantId",
                table: "ProductVariantItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompanyDeliveryId",
                table: "Transactions",
                column: "CompanyDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AdminId",
                table: "UserAddresses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_VendorId",
                table: "UserAddresses",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoupons_UserId",
                table: "UserCoupons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorProducts_VendorId",
                table: "VendorProducts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_RoleId",
                table: "Vendors",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorTransactions_transactionMoneyId",
                table: "VendorTransactions",
                column: "transactionMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminBrands");

            migrationBuilder.DropTable(
                name: "AdminCategories");

            migrationBuilder.DropTable(
                name: "AdminOrders");

            migrationBuilder.DropTable(
                name: "AdminProducts");

            migrationBuilder.DropTable(
                name: "AdminTransactions");

            migrationBuilder.DropTable(
                name: "AdminVendorConditions");

            migrationBuilder.DropTable(
                name: "AdminVendors");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "checkUserNameAndEmails");

            migrationBuilder.DropTable(
                name: "ClaimAdmins");

            migrationBuilder.DropTable(
                name: "ClaimRoles");

            migrationBuilder.DropTable(
                name: "ClaimUsers");

            migrationBuilder.DropTable(
                name: "ClaimVendors");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "OrderVendorOrders");

            migrationBuilder.DropTable(
                name: "PaypalSettings");

            migrationBuilder.DropTable(
                name: "ProductImageGalleries");

            migrationBuilder.DropTable(
                name: "ProductReviewGalleries");

            migrationBuilder.DropTable(
                name: "PusherSettings");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserCoupons");

            migrationBuilder.DropTable(
                name: "VendorProducts");

            migrationBuilder.DropTable(
                name: "VendorTransactions");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "VendorConditions");

            migrationBuilder.DropTable(
                name: "ProductVariantItems");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DeliveryCompanies");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
