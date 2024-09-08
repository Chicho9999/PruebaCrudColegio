using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaCrudColegio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => new { x.StudentId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_StudentGrade_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGrade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "FirstName", "Gender", "IsDeleted", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("9ba804fb-e068-4c49-8754-4beb6437de51"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Angela", "F", false, "Perez", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Alejandro", "M", false, "Lopez", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDay", "DateCreated", "DateDeleted", "DateUpdated", "FirstName", "Gender", "IsDeleted", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Carlos", "M", false, "Chichi", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f4e9bc25-f21e-473a-bdd3-cee5cacbdf2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Antonella", "F", false, "Perez", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "ProfessorId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, -3, 0, 0, 0)), null, null, false, "Privada", new Guid("9ba804fb-e068-4c49-8754-4beb6437de51"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, -3, 0, 0, 0)), null, null, false, "Normal", new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "StudentGrade",
                columns: new[] { "GradeId", "StudentId", "DateCreated", "DateDeleted", "DateUpdated", "Id", "IsDeleted", "Section", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, -3, 0, 0, 0)), null, null, new Guid("719a943a-1d01-457f-81ef-a17785149984"), false, 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2"), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, -3, 0, 0, 0)), null, null, new Guid("d9f24076-84ae-48b4-8ac4-732c4e8701e3"), false, 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_ProfessorId",
                table: "Grade",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_GradeId",
                table: "StudentGrade",
                column: "GradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
