using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IT_ESTADO_AUTORIZACION",
                columns: table => new
                {
                    ESTADO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_ESTADO_AUTORIZACION", x => x.ESTADO_ID);
                });

            migrationBuilder.CreateTable(
                name: "IT_MOTIVO_AUTORIZACION",
                columns: table => new
                {
                    MOTIVO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_MOTIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_MOTIVO_AUTORIZACION", x => x.MOTIVO_ID);
                });

            migrationBuilder.CreateTable(
                name: "IT_TIPO_CONTENIDO",
                columns: table => new
                {
                    TIPO_CONTENIDO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_TIPO_CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_TIPO_CONTENIDO", x => x.TIPO_CONTENIDO_ID);
                });

            migrationBuilder.CreateTable(
                name: "IT_AUTORIZACION",
                columns: table => new
                {
                    AUTORIZACION_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO_CREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_AREA_FUNCIONAL = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ID_MOTIVO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    RETORNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HORA_SALIDA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_RETORNO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_SALIDA_SEGURIDAD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_RETORNO_SEGURIDAD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_AUTORIZA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_TIPO_USUARIO = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_EDICION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_EDITA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_ESTADO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_ULTIMO_ESTADO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_SALIDA_PROG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_RETORNO_PROG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOMBRE_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIPO_CONTENIDO_FILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_AUTORIZACION", x => x.AUTORIZACION_ID);
                    table.ForeignKey(
                        name: "FK_IT_AUTORIZACION_IT_ESTADO_AUTORIZACION_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "IT_ESTADO_AUTORIZACION",
                        principalColumn: "ESTADO_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IT_AUTORIZACION_IT_MOTIVO_AUTORIZACION_ID_MOTIVO",
                        column: x => x.ID_MOTIVO,
                        principalTable: "IT_MOTIVO_AUTORIZACION",
                        principalColumn: "MOTIVO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IT_CONTENIDO_GENERAL",
                columns: table => new
                {
                    CONTENIDO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPCION_CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIPO_CONTENIDO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    NOMBRE_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UBICACION_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_AREA_FUNCIONAL = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    USUARIO_CREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_EDITA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_EDICION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FILE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TIPO_CONTENIDO_FILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_CONTENIDO_GENERAL", x => x.CONTENIDO_ID);
                    table.ForeignKey(
                        name: "FK_IT_CONTENIDO_GENERAL_IT_TIPO_CONTENIDO_TIPO_CONTENIDO_ID",
                        column: x => x.TIPO_CONTENIDO_ID,
                        principalTable: "IT_TIPO_CONTENIDO",
                        principalColumn: "TIPO_CONTENIDO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IT_AUTORIZACION_AUDITORIA",
                columns: table => new
                {
                    AUTORIZACION_AUDITORIA_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTORIZACION_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    USUARIO_CREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_AREA_FUNCIONAL = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ID_MOTIVO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    RETORNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HORA_SALIDA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_RETORNO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_SALIDA_SEGURIDAD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HORA_RETORNO_SEGURIDAD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_AUTORIZA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_TIPO_USUARIO = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_EDICION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_EDITA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_ESTADO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_ULTIMO_ESTADO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_SALIDA_PROG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_RETORNO_PROG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOMBRE_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIPO_CONTENIDO_FILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TIPO_MOVIMIENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_MOVIMIENTO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_AUTORIZACION_AUDITORIA", x => x.AUTORIZACION_AUDITORIA_ID);
                    table.ForeignKey(
                        name: "FK_IT_AUTORIZACION_AUDITORIA_IT_AUTORIZACION_AUTORIZACION_ID",
                        column: x => x.AUTORIZACION_ID,
                        principalTable: "IT_AUTORIZACION",
                        principalColumn: "AUTORIZACION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IT_AUTORIZACION_MOVIMIENTOS",
                columns: table => new
                {
                    MOVIMIENTO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_AUTORIZACION = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    ID_ESTADO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    USUARIO_CREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_MOTIVO = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    ID_AREA_FUNCIONAL = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ID_USUARIO_AUTORIZA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_TIPO_USUARIO = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_AUTORIZACION_MOVIMIENTOS", x => x.MOVIMIENTO_ID);
                    table.ForeignKey(
                        name: "FK_IT_AUTORIZACION_MOVIMIENTOS_IT_AUTORIZACION_ID_AUTORIZACION",
                        column: x => x.ID_AUTORIZACION,
                        principalTable: "IT_AUTORIZACION",
                        principalColumn: "AUTORIZACION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IT_CONTENIDO_GENERAL_AUDITORIA",
                columns: table => new
                {
                    CONTENIDO_GENERAL_AUDITORIA_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENIDO_ID = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    NOMBRE_CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPCION_CONTENIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_TIPO_CONTENIDO = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    NOMBRE_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UBICACION_ARCHIVO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_AREA_FUNCIONAL = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    USUARIO_CREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_EDITA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FECHA_EDICION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FILE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TIPO_CONTENIDO_FILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_INGRESA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_INGRESA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_MODIFICA = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    FECHA_MODIFICA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TIPO_MOVIMIENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_MOVIMIENTO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_CONTENIDO_GENERAL_AUDITORIA", x => x.CONTENIDO_GENERAL_AUDITORIA_ID);
                    table.ForeignKey(
                        name: "FK_IT_CONTENIDO_GENERAL_AUDITORIA_IT_CONTENIDO_GENERAL_CONTENIDO_ID",
                        column: x => x.CONTENIDO_ID,
                        principalTable: "IT_CONTENIDO_GENERAL",
                        principalColumn: "CONTENIDO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IT_AUTORIZACION_ID_ESTADO",
                table: "IT_AUTORIZACION",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_IT_AUTORIZACION_ID_MOTIVO",
                table: "IT_AUTORIZACION",
                column: "ID_MOTIVO");

            migrationBuilder.CreateIndex(
                name: "IX_IT_AUTORIZACION_AUDITORIA_AUTORIZACION_ID",
                table: "IT_AUTORIZACION_AUDITORIA",
                column: "AUTORIZACION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IT_AUTORIZACION_MOVIMIENTOS_ID_AUTORIZACION",
                table: "IT_AUTORIZACION_MOVIMIENTOS",
                column: "ID_AUTORIZACION");

            migrationBuilder.CreateIndex(
                name: "IX_IT_CONTENIDO_GENERAL_TIPO_CONTENIDO_ID",
                table: "IT_CONTENIDO_GENERAL",
                column: "TIPO_CONTENIDO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IT_CONTENIDO_GENERAL_AUDITORIA_CONTENIDO_ID",
                table: "IT_CONTENIDO_GENERAL_AUDITORIA",
                column: "CONTENIDO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IT_AUTORIZACION_AUDITORIA");

            migrationBuilder.DropTable(
                name: "IT_AUTORIZACION_MOVIMIENTOS");

            migrationBuilder.DropTable(
                name: "IT_CONTENIDO_GENERAL_AUDITORIA");

            migrationBuilder.DropTable(
                name: "IT_AUTORIZACION");

            migrationBuilder.DropTable(
                name: "IT_CONTENIDO_GENERAL");

            migrationBuilder.DropTable(
                name: "IT_ESTADO_AUTORIZACION");

            migrationBuilder.DropTable(
                name: "IT_MOTIVO_AUTORIZACION");

            migrationBuilder.DropTable(
                name: "IT_TIPO_CONTENIDO");
        }
    }
}
