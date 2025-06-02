using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t003_presupuesto_AspNetUsers_f002_usuario_id",
                table: "t003_presupuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_t004_gasto_encabezado_t002_fondo_monetario_f003_fondo_monetario_id",
                table: "t004_gasto_encabezado");

            migrationBuilder.DropForeignKey(
                name: "FK_t005_gasto_detalle_t001_tipo_gasto_f003_tipo_gasto_id",
                table: "t005_gasto_detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_t005_gasto_detalle_t004_gasto_encabezado_f002_encabezado_id",
                table: "t005_gasto_detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_t006_deposito_t002_fondo_monetario_f003_fondo_monetario_id",
                table: "t006_deposito");

            migrationBuilder.RenameColumn(
                name: "f004_monto",
                table: "t006_deposito",
                newName: "f006_monto");

            migrationBuilder.RenameColumn(
                name: "f003_fondo_monetario_id",
                table: "t006_deposito",
                newName: "f006_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f002_fecha",
                table: "t006_deposito",
                newName: "f006_fecha");

            migrationBuilder.RenameColumn(
                name: "f001_rowid",
                table: "t006_deposito",
                newName: "f006_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t006_deposito_f003_fondo_monetario_id",
                table: "t006_deposito",
                newName: "IX_t006_deposito_f006_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f004_monto",
                table: "t005_gasto_detalle",
                newName: "f005_monto");

            migrationBuilder.RenameColumn(
                name: "f003_tipo_gasto_id",
                table: "t005_gasto_detalle",
                newName: "f005_tipo_gasto_id");

            migrationBuilder.RenameColumn(
                name: "f002_encabezado_id",
                table: "t005_gasto_detalle",
                newName: "f005_encabezado_id");

            migrationBuilder.RenameColumn(
                name: "f001_rowid",
                table: "t005_gasto_detalle",
                newName: "f005_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t005_gasto_detalle_f003_tipo_gasto_id",
                table: "t005_gasto_detalle",
                newName: "IX_t005_gasto_detalle_f005_tipo_gasto_id");

            migrationBuilder.RenameIndex(
                name: "IX_t005_gasto_detalle_f002_encabezado_id",
                table: "t005_gasto_detalle",
                newName: "IX_t005_gasto_detalle_f005_encabezado_id");

            migrationBuilder.RenameColumn(
                name: "f006_tipo_documento",
                table: "t004_gasto_encabezado",
                newName: "f004_tipo_documento");

            migrationBuilder.RenameColumn(
                name: "f005_nombre_comercio",
                table: "t004_gasto_encabezado",
                newName: "f004_nombre_comercio");

            migrationBuilder.RenameColumn(
                name: "f003_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                newName: "f004_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f002_fecha",
                table: "t004_gasto_encabezado",
                newName: "f004_fecha");

            migrationBuilder.RenameColumn(
                name: "f001_rowid",
                table: "t004_gasto_encabezado",
                newName: "f004_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t004_gasto_encabezado_f003_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                newName: "IX_t004_gasto_encabezado_f004_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f006_monto",
                table: "t003_presupuesto",
                newName: "f003_monto");

            migrationBuilder.RenameColumn(
                name: "f005_anio",
                table: "t003_presupuesto",
                newName: "f003_anio");

            migrationBuilder.RenameColumn(
                name: "f004_mes",
                table: "t003_presupuesto",
                newName: "f003_mes");

            migrationBuilder.RenameColumn(
                name: "f002_usuario_id",
                table: "t003_presupuesto",
                newName: "f003_usuario_id");

            migrationBuilder.RenameColumn(
                name: "f001_rowid",
                table: "t003_presupuesto",
                newName: "f003_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t003_presupuesto_f002_usuario_id",
                table: "t003_presupuesto",
                newName: "IX_t003_presupuesto_f003_usuario_id");

            migrationBuilder.RenameColumn(
                name: "f003_tipo",
                table: "t002_fondo_monetario",
                newName: "f002_tipo");

            migrationBuilder.RenameColumn(
                name: "f001_rowid",
                table: "t002_fondo_monetario",
                newName: "f002_rowid");

            migrationBuilder.RenameColumn(
                name: "f003_Descripcion",
                table: "t001_tipo_gasto",
                newName: "f001_Descripcion");

            migrationBuilder.RenameColumn(
                name: "f002_nombre",
                table: "t001_tipo_gasto",
                newName: "f001_nombre");

            migrationBuilder.RenameIndex(
                name: "IX_t001_tipo_gasto_f002_nombre",
                table: "t001_tipo_gasto",
                newName: "IX_t001_tipo_gasto_f001_nombre");

            migrationBuilder.AddForeignKey(
                name: "FK_t003_presupuesto_AspNetUsers_f003_usuario_id",
                table: "t003_presupuesto",
                column: "f003_usuario_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t004_gasto_encabezado_t002_fondo_monetario_f004_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                column: "f004_fondo_monetario_id",
                principalTable: "t002_fondo_monetario",
                principalColumn: "f002_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t005_gasto_detalle_t001_tipo_gasto_f005_tipo_gasto_id",
                table: "t005_gasto_detalle",
                column: "f005_tipo_gasto_id",
                principalTable: "t001_tipo_gasto",
                principalColumn: "f001_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t005_gasto_detalle_t004_gasto_encabezado_f005_encabezado_id",
                table: "t005_gasto_detalle",
                column: "f005_encabezado_id",
                principalTable: "t004_gasto_encabezado",
                principalColumn: "f004_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t006_deposito_t002_fondo_monetario_f006_fondo_monetario_id",
                table: "t006_deposito",
                column: "f006_fondo_monetario_id",
                principalTable: "t002_fondo_monetario",
                principalColumn: "f002_rowid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t003_presupuesto_AspNetUsers_f003_usuario_id",
                table: "t003_presupuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_t004_gasto_encabezado_t002_fondo_monetario_f004_fondo_monetario_id",
                table: "t004_gasto_encabezado");

            migrationBuilder.DropForeignKey(
                name: "FK_t005_gasto_detalle_t001_tipo_gasto_f005_tipo_gasto_id",
                table: "t005_gasto_detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_t005_gasto_detalle_t004_gasto_encabezado_f005_encabezado_id",
                table: "t005_gasto_detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_t006_deposito_t002_fondo_monetario_f006_fondo_monetario_id",
                table: "t006_deposito");

            migrationBuilder.RenameColumn(
                name: "f006_monto",
                table: "t006_deposito",
                newName: "f004_monto");

            migrationBuilder.RenameColumn(
                name: "f006_fondo_monetario_id",
                table: "t006_deposito",
                newName: "f003_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f006_fecha",
                table: "t006_deposito",
                newName: "f002_fecha");

            migrationBuilder.RenameColumn(
                name: "f006_rowid",
                table: "t006_deposito",
                newName: "f001_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t006_deposito_f006_fondo_monetario_id",
                table: "t006_deposito",
                newName: "IX_t006_deposito_f003_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f005_tipo_gasto_id",
                table: "t005_gasto_detalle",
                newName: "f003_tipo_gasto_id");

            migrationBuilder.RenameColumn(
                name: "f005_monto",
                table: "t005_gasto_detalle",
                newName: "f004_monto");

            migrationBuilder.RenameColumn(
                name: "f005_encabezado_id",
                table: "t005_gasto_detalle",
                newName: "f002_encabezado_id");

            migrationBuilder.RenameColumn(
                name: "f005_rowid",
                table: "t005_gasto_detalle",
                newName: "f001_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t005_gasto_detalle_f005_tipo_gasto_id",
                table: "t005_gasto_detalle",
                newName: "IX_t005_gasto_detalle_f003_tipo_gasto_id");

            migrationBuilder.RenameIndex(
                name: "IX_t005_gasto_detalle_f005_encabezado_id",
                table: "t005_gasto_detalle",
                newName: "IX_t005_gasto_detalle_f002_encabezado_id");

            migrationBuilder.RenameColumn(
                name: "f004_tipo_documento",
                table: "t004_gasto_encabezado",
                newName: "f006_tipo_documento");

            migrationBuilder.RenameColumn(
                name: "f004_nombre_comercio",
                table: "t004_gasto_encabezado",
                newName: "f005_nombre_comercio");

            migrationBuilder.RenameColumn(
                name: "f004_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                newName: "f003_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f004_fecha",
                table: "t004_gasto_encabezado",
                newName: "f002_fecha");

            migrationBuilder.RenameColumn(
                name: "f004_rowid",
                table: "t004_gasto_encabezado",
                newName: "f001_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t004_gasto_encabezado_f004_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                newName: "IX_t004_gasto_encabezado_f003_fondo_monetario_id");

            migrationBuilder.RenameColumn(
                name: "f003_usuario_id",
                table: "t003_presupuesto",
                newName: "f002_usuario_id");

            migrationBuilder.RenameColumn(
                name: "f003_monto",
                table: "t003_presupuesto",
                newName: "f006_monto");

            migrationBuilder.RenameColumn(
                name: "f003_mes",
                table: "t003_presupuesto",
                newName: "f004_mes");

            migrationBuilder.RenameColumn(
                name: "f003_anio",
                table: "t003_presupuesto",
                newName: "f005_anio");

            migrationBuilder.RenameColumn(
                name: "f003_rowid",
                table: "t003_presupuesto",
                newName: "f001_rowid");

            migrationBuilder.RenameIndex(
                name: "IX_t003_presupuesto_f003_usuario_id",
                table: "t003_presupuesto",
                newName: "IX_t003_presupuesto_f002_usuario_id");

            migrationBuilder.RenameColumn(
                name: "f002_tipo",
                table: "t002_fondo_monetario",
                newName: "f003_tipo");

            migrationBuilder.RenameColumn(
                name: "f002_rowid",
                table: "t002_fondo_monetario",
                newName: "f001_rowid");

            migrationBuilder.RenameColumn(
                name: "f001_nombre",
                table: "t001_tipo_gasto",
                newName: "f002_nombre");

            migrationBuilder.RenameColumn(
                name: "f001_Descripcion",
                table: "t001_tipo_gasto",
                newName: "f003_Descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_t001_tipo_gasto_f001_nombre",
                table: "t001_tipo_gasto",
                newName: "IX_t001_tipo_gasto_f002_nombre");

            migrationBuilder.AddForeignKey(
                name: "FK_t003_presupuesto_AspNetUsers_f002_usuario_id",
                table: "t003_presupuesto",
                column: "f002_usuario_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t004_gasto_encabezado_t002_fondo_monetario_f003_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                column: "f003_fondo_monetario_id",
                principalTable: "t002_fondo_monetario",
                principalColumn: "f001_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t005_gasto_detalle_t001_tipo_gasto_f003_tipo_gasto_id",
                table: "t005_gasto_detalle",
                column: "f003_tipo_gasto_id",
                principalTable: "t001_tipo_gasto",
                principalColumn: "f001_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t005_gasto_detalle_t004_gasto_encabezado_f002_encabezado_id",
                table: "t005_gasto_detalle",
                column: "f002_encabezado_id",
                principalTable: "t004_gasto_encabezado",
                principalColumn: "f001_rowid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t006_deposito_t002_fondo_monetario_f003_fondo_monetario_id",
                table: "t006_deposito",
                column: "f003_fondo_monetario_id",
                principalTable: "t002_fondo_monetario",
                principalColumn: "f001_rowid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
