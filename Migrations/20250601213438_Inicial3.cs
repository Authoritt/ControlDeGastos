using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t001_tipo_gasto_f002_codigo",
                table: "t001_tipo_gasto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_t001_tipo_gasto_f002_codigo",
                table: "t001_tipo_gasto",
                column: "f002_codigo",
                unique: true);
        }
    }
}
