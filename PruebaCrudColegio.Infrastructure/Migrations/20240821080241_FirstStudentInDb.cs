using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaCrudColegio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstStudentInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "College",
                columns: new[] { "ID", "Address", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name", "UserID" },
                values: new object[] { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), "Tucuman 868", new DateTimeOffset(new DateTime(2024, 8, 21, 5, 2, 39, 713, DateTimeKind.Unspecified).AddTicks(5420), new TimeSpan(0, -3, 0, 0, 0)), null, null, false, "Normal", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "CollegeId", "DateCreated", "DateDeleted", "DateUpdated", "FirstName", "IsDeleted", "LastName", "UserID" },
                values: new object[] { new Guid("76a4f121-4800-44f2-93b7-6d8e06713da4"), new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new DateTimeOffset(new DateTime(2024, 8, 21, 5, 2, 39, 713, DateTimeKind.Unspecified).AddTicks(5522), new TimeSpan(0, -3, 0, 0, 0)), null, null, "Lisandro", false, "Test Description", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeId",
                table: "Students",
                column: "CollegeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "College");
        }
    }
}
