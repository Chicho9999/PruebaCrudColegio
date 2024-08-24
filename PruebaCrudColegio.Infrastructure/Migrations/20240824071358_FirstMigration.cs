using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaCrudColegio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "Id", "Address", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"), "Buenos Aires 80", new DateTimeOffset(new DateTime(2024, 8, 24, 4, 13, 58, 520, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, -3, 0, 0, 0)), null, null, false, "Privada", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), "Tucuman 868", new DateTimeOffset(new DateTime(2024, 8, 24, 4, 13, 58, 520, DateTimeKind.Unspecified).AddTicks(5048), new TimeSpan(0, -3, 0, 0, 0)), null, null, false, "Normal", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "CollegeId", "DateCreated", "DateDeleted", "DateUpdated", "FirstName", "IsDeleted", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("9ba804fb-e068-4c49-8754-4beb6437de51"), new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new DateTimeOffset(new DateTime(2024, 8, 24, 4, 13, 58, 520, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Angel", false, "Perez", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"), new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new DateTimeOffset(new DateTime(2024, 8, 24, 4, 13, 58, 520, DateTimeKind.Unspecified).AddTicks(5093), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Alejandro", false, "Lopez", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CollegeId", "DateCreated", "DateDeleted", "DateUpdated", "FirstName", "IsDeleted", "LastName", "ProfessorId", "UserId" },
                values: new object[] { new Guid("d0d3f3a0-fdb3-418d-aecf-aaf451ffdd82"), new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new DateTimeOffset(new DateTime(2024, 8, 24, 4, 13, 58, 520, DateTimeKind.Unspecified).AddTicks(5098), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Lisandro", false, "Test Description", new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Professors_CollegeId",
                table: "Professors",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeId",
                table: "Students",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProfessorId",
                table: "Students",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Colleges");
        }
    }
}
