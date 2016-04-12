using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace TopAtlantaRealEstate.Migrations
{
    public partial class InitialTopAtlantaDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerCustomerId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Email_Customer_CustomerCustomerId",
                        column: x => x.CustomerCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerCustomerId = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Customer_CustomerCustomerId",
                        column: x => x.CustomerCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Email");
            migrationBuilder.DropTable("Phone");
            migrationBuilder.DropTable("Customer");
        }
    }
}
