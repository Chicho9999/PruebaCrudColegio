using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaCrudColegio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Grade",
                keyColumn: "Id",
                keyValue: new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Grade",
                keyColumn: "Id",
                keyValue: new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: new Guid("9ba804fb-e068-4c49-8754-4beb6437de51"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2"),
                columns: new[] { "BirthDay", "DateCreated" },
                values: new object[] { new DateTime(1995, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(5989), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("f4e9bc25-f21e-473a-bdd3-cee5cacbdf2e"),
                columns: new[] { "BirthDay", "DateCreated" },
                values: new object[] { new DateTime(1993, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "StudentGrade",
                keyColumns: new[] { "GradeId", "StudentId" },
                keyValues: new object[] { new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2") },
                columns: new[] { "DateCreated", "Id" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, -3, 0, 0, 0)), new Guid("04761a8e-c223-43a5-8e7d-f2069c7672e1") });

            migrationBuilder.UpdateData(
                table: "StudentGrade",
                keyColumns: new[] { "GradeId", "StudentId" },
                keyValues: new object[] { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2") },
                columns: new[] { "DateCreated", "Id" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 13, 8, 8, 12, 503, DateTimeKind.Unspecified).AddTicks(6092), new TimeSpan(0, -3, 0, 0, 0)), new Guid("36fe9953-01a4-436f-9b31-c52ad7d45f16") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Grade",
                keyColumn: "Id",
                keyValue: new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2419), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Grade",
                keyColumn: "Id",
                keyValue: new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: new Guid("9ba804fb-e068-4c49-8754-4beb6437de51"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Professor",
                keyColumn: "Id",
                keyValue: new Guid("a0327b17-49d7-499f-97e1-cfd28df1b094"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2370), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2"),
                columns: new[] { "BirthDay", "DateCreated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2422), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("f4e9bc25-f21e-473a-bdd3-cee5cacbdf2e"),
                columns: new[] { "BirthDay", "DateCreated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2424), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "StudentGrade",
                keyColumns: new[] { "GradeId", "StudentId" },
                keyValues: new object[] { new Guid("5f85a554-16c7-4780-96aa-7dad227fb974"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2") },
                columns: new[] { "DateCreated", "Id" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, -3, 0, 0, 0)), new Guid("719a943a-1d01-457f-81ef-a17785149984") });

            migrationBuilder.UpdateData(
                table: "StudentGrade",
                keyColumns: new[] { "GradeId", "StudentId" },
                keyValues: new object[] { new Guid("9cbea81b-aada-4f31-8250-467bb3a5c0aa"), new Guid("0b6682c4-0841-4612-b1fd-4a9d565543e2") },
                columns: new[] { "DateCreated", "Id" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 8, 4, 57, 32, 108, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, -3, 0, 0, 0)), new Guid("d9f24076-84ae-48b4-8ac4-732c4e8701e3") });
        }
    }
}
