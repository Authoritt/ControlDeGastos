using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "e2693d7a-967c-47fe-b18f-67fc4218c546", "admin@controlgastos.com", true, false, null, "ADMIN@CONTROLGASTOS.COM", "ADMIN", "AQAAAAIAAYagAAAAEKgH/QS/eLD3sDK3bJIJSmKUnZgIi2d42tLFjQIRS695FHt422b8q+GVjCniJVPZEg==", null, false, "", false, "admin" });
        }
    }
}
