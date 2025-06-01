using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t001_tipo_gasto_f002_codigo",
                table: "t001_tipo_gasto");

            migrationBuilder.DropColumn(
                name: "f002_codigo",
                table: "t001_tipo_gasto");

            migrationBuilder.RenameColumn(
                name: "f003_nombre",
                table: "t001_tipo_gasto",
                newName: "f002_nombre");

            migrationBuilder.AlterColumn<string>(
                name: "f002_nombre",
                table: "t001_tipo_gasto",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "f003_Descripcion",
                table: "t001_tipo_gasto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_t001_tipo_gasto_f002_nombre",
                table: "t001_tipo_gasto",
                column: "f002_nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t001_tipo_gasto_f002_nombre",
                table: "t001_tipo_gasto");

            migrationBuilder.DropColumn(
                name: "f003_Descripcion",
                table: "t001_tipo_gasto");

            migrationBuilder.RenameColumn(
                name: "f002_nombre",
                table: "t001_tipo_gasto",
                newName: "f003_nombre");

            migrationBuilder.AlterColumn<string>(
                name: "f003_nombre",
                table: "t001_tipo_gasto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddColumn<string>(
                name: "f002_codigo",
                table: "t001_tipo_gasto",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_t001_tipo_gasto_f002_codigo",
                table: "t001_tipo_gasto",
                column: "f002_codigo",
                unique: true);
        }
    }
}
