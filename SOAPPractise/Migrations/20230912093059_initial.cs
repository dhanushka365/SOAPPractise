using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SOAPPractise.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("14977c82-4005-4831-a4aa-4607e64174dd"), "Managed Services" },
                    { new Guid("41804ac3-f675-42aa-8796-4a8b2ddb9ed9"), "Support" },
                    { new Guid("4c1bd9a6-ae71-4c3d-9c11-e0e70a7d3a6b"), "Human Resource" },
                    { new Guid("730a74ec-14a8-4692-ae92-cdd1a4117782"), "Engineering" },
                    { new Guid("da87329a-5cd4-4917-b506-3f088109544d"), "Quality Assuarance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
