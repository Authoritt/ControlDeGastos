using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t001_tipo_gasto",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    f003_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t001_tipo_gasto", x => x.f001_rowid);
                });

            migrationBuilder.CreateTable(
                name: "t002_fondo_monetario",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    f003_tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t002_fondo_monetario", x => x.f001_rowid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t003_presupuesto",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_usuario_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    f003_tipo_gasto_id = table.Column<int>(type: "int", nullable: false),
                    f004_mes = table.Column<int>(type: "int", nullable: false),
                    f005_anio = table.Column<int>(type: "int", nullable: false),
                    f006_monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t003_presupuesto", x => x.f001_rowid);
                    table.ForeignKey(
                        name: "FK_t003_presupuesto_AspNetUsers_f002_usuario_id",
                        column: x => x.f002_usuario_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t003_presupuesto_t001_tipo_gasto_f003_tipo_gasto_id",
                        column: x => x.f003_tipo_gasto_id,
                        principalTable: "t001_tipo_gasto",
                        principalColumn: "f001_rowid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t004_gasto_encabezado",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    f003_fondo_monetario_id = table.Column<int>(type: "int", nullable: false),
                    f004_observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    f005_nombre_comercio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    f006_tipo_documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t004_gasto_encabezado", x => x.f001_rowid);
                    table.ForeignKey(
                        name: "FK_t004_gasto_encabezado_t002_fondo_monetario_f003_fondo_monetario_id",
                        column: x => x.f003_fondo_monetario_id,
                        principalTable: "t002_fondo_monetario",
                        principalColumn: "f001_rowid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t006_deposito",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    f003_fondo_monetario_id = table.Column<int>(type: "int", nullable: false),
                    f004_monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t006_deposito", x => x.f001_rowid);
                    table.ForeignKey(
                        name: "FK_t006_deposito_t002_fondo_monetario_f003_fondo_monetario_id",
                        column: x => x.f003_fondo_monetario_id,
                        principalTable: "t002_fondo_monetario",
                        principalColumn: "f001_rowid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t005_gasto_detalle",
                columns: table => new
                {
                    f001_rowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f002_encabezado_id = table.Column<int>(type: "int", nullable: false),
                    f003_tipo_gasto_id = table.Column<int>(type: "int", nullable: false),
                    f004_monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t005_gasto_detalle", x => x.f001_rowid);
                    table.ForeignKey(
                        name: "FK_t005_gasto_detalle_t001_tipo_gasto_f003_tipo_gasto_id",
                        column: x => x.f003_tipo_gasto_id,
                        principalTable: "t001_tipo_gasto",
                        principalColumn: "f001_rowid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t005_gasto_detalle_t004_gasto_encabezado_f002_encabezado_id",
                        column: x => x.f002_encabezado_id,
                        principalTable: "t004_gasto_encabezado",
                        principalColumn: "f001_rowid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "e2693d7a-967c-47fe-b18f-67fc4218c546", "admin@controlgastos.com", true, false, null, "ADMIN@CONTROLGASTOS.COM", "ADMIN", "AQAAAAIAAYagAAAAEKgH/QS/eLD3sDK3bJIJSmKUnZgIi2d42tLFjQIRS695FHt422b8q+GVjCniJVPZEg==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_t001_tipo_gasto_f002_codigo",
                table: "t001_tipo_gasto",
                column: "f002_codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t003_presupuesto_f002_usuario_id",
                table: "t003_presupuesto",
                column: "f002_usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_t003_presupuesto_f003_tipo_gasto_id",
                table: "t003_presupuesto",
                column: "f003_tipo_gasto_id");

            migrationBuilder.CreateIndex(
                name: "IX_t004_gasto_encabezado_f003_fondo_monetario_id",
                table: "t004_gasto_encabezado",
                column: "f003_fondo_monetario_id");

            migrationBuilder.CreateIndex(
                name: "IX_t005_gasto_detalle_f002_encabezado_id",
                table: "t005_gasto_detalle",
                column: "f002_encabezado_id");

            migrationBuilder.CreateIndex(
                name: "IX_t005_gasto_detalle_f003_tipo_gasto_id",
                table: "t005_gasto_detalle",
                column: "f003_tipo_gasto_id");

            migrationBuilder.CreateIndex(
                name: "IX_t006_deposito_f003_fondo_monetario_id",
                table: "t006_deposito",
                column: "f003_fondo_monetario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "t003_presupuesto");

            migrationBuilder.DropTable(
                name: "t005_gasto_detalle");

            migrationBuilder.DropTable(
                name: "t006_deposito");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "t001_tipo_gasto");

            migrationBuilder.DropTable(
                name: "t004_gasto_encabezado");

            migrationBuilder.DropTable(
                name: "t002_fondo_monetario");
        }
    }
}
