using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class inIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agent",
                columns: table => new
                {
                    reactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    longName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    disc = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent", x => x.reactionID);
                });

            migrationBuilder.CreateTable(
                name: "alergicsym",
                columns: table => new
                {
                    drugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    disc = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alergicsym", x => x.drugID);
                });

            migrationBuilder.CreateTable(
                name: "antialergy",
                columns: table => new
                {
                    antidrugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    longName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    disc = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_antialergy", x => x.antidrugID);
                });

            migrationBuilder.CreateTable(
                name: "drugs",
                columns: table => new
                {
                    drugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    longName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    disc = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    analyse = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugs", x => x.drugID);
                });

            migrationBuilder.CreateTable(
                name: "employes",
                columns: table => new
                {
                    empID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    datejoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dept = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    designationn = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employes", x => x.empID);
                });

            migrationBuilder.CreateTable(
                name: "regist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Confirmpwd = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "usages",
                columns: table => new
                {
                    drugcondID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disc = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    otherdetails = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usages", x => x.drugcondID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent");

            migrationBuilder.DropTable(
                name: "alergicsym");

            migrationBuilder.DropTable(
                name: "antialergy");

            migrationBuilder.DropTable(
                name: "drugs");

            migrationBuilder.DropTable(
                name: "employes");

            migrationBuilder.DropTable(
                name: "regist");

            migrationBuilder.DropTable(
                name: "usages");
        }
    }
}
