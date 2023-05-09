using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations;

/// <inheritdoc />
public partial class MigrationD : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Alergias",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NombreInterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Alergias", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UsuariosEmpresas",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Cif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TelefonoDirector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CorreoElectronicoDirector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Puntuacion = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsuariosEmpresas", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UsuariosOngs",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NombreOng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Cif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TelefonoDirector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CorreoElectronicoDirector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Puntuacion = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsuariosOngs", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UsuariosProveedores",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DireccionDomicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Puntuacion = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsuariosProveedores", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UsuariosReceptores",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsuariosReceptores", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Eventos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UsuarioProveedorId = table.Column<int>(type: "int", nullable: true),
                UsuarioEmpresaId = table.Column<int>(type: "int", nullable: true),
                UsuarioOngId = table.Column<int>(type: "int", nullable: true),
                NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CantidadPublicadaProducto = table.Column<int>(type: "int", nullable: false),
                UnidadesRestantes = table.Column<int>(type: "int", nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Longitud = table.Column<decimal>(type: "decimal(12,7)", precision: 12, scale: 7, nullable: false),
                Latitud = table.Column<decimal>(type: "decimal(12,7)", precision: 12, scale: 7, nullable: false),
                FechaHoraInicio = table.Column<DateTime>(type: "datetime2(0)", precision: 0, scale: 0, nullable: false),
                FechaHoraFin = table.Column<DateTime>(type: "datetime2(0)", precision: 0, scale: 0, nullable: false),
                CategoriaHoraria = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Eventos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Eventos_UsuariosEmpresas_UsuarioEmpresaId",
                    column: x => x.UsuarioEmpresaId,
                    principalTable: "UsuariosEmpresas",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Eventos_UsuariosOngs_UsuarioOngId",
                    column: x => x.UsuarioOngId,
                    principalTable: "UsuariosOngs",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Eventos_UsuariosProveedores_UsuarioProveedorId",
                    column: x => x.UsuarioProveedorId,
                    principalTable: "UsuariosProveedores",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "AlergiaEvento",
            columns: table => new
            {
                AlergiasId = table.Column<int>(type: "int", nullable: false),
                EventosId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AlergiaEvento", x => new { x.AlergiasId, x.EventosId });
                table.ForeignKey(
                    name: "FK_AlergiaEvento_Alergias_AlergiasId",
                    column: x => x.AlergiasId,
                    principalTable: "Alergias",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AlergiaEvento_Eventos_EventosId",
                    column: x => x.EventosId,
                    principalTable: "Eventos",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EventoUsuarioReceptor",
            columns: table => new
            {
                EventosId = table.Column<int>(type: "int", nullable: false),
                UsuariosReceptoresId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EventoUsuarioReceptor", x => new { x.EventosId, x.UsuariosReceptoresId });
                table.ForeignKey(
                    name: "FK_EventoUsuarioReceptor_Eventos_EventosId",
                    column: x => x.EventosId,
                    principalTable: "Eventos",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EventoUsuarioReceptor_UsuariosReceptores_UsuariosReceptoresId",
                    column: x => x.UsuariosReceptoresId,
                    principalTable: "UsuariosReceptores",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AlergiaEvento_EventosId",
            table: "AlergiaEvento",
            column: "EventosId");

        migrationBuilder.CreateIndex(
            name: "IX_Eventos_UsuarioEmpresaId",
            table: "Eventos",
            column: "UsuarioEmpresaId");

        migrationBuilder.CreateIndex(
            name: "IX_Eventos_UsuarioOngId",
            table: "Eventos",
            column: "UsuarioOngId");

        migrationBuilder.CreateIndex(
            name: "IX_Eventos_UsuarioProveedorId",
            table: "Eventos",
            column: "UsuarioProveedorId");

        migrationBuilder.CreateIndex(
            name: "IX_EventoUsuarioReceptor_UsuariosReceptoresId",
            table: "EventoUsuarioReceptor",
            column: "UsuariosReceptoresId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AlergiaEvento");

        migrationBuilder.DropTable(
            name: "EventoUsuarioReceptor");

        migrationBuilder.DropTable(
            name: "Alergias");

        migrationBuilder.DropTable(
            name: "Eventos");

        migrationBuilder.DropTable(
            name: "UsuariosReceptores");

        migrationBuilder.DropTable(
            name: "UsuariosEmpresas");

        migrationBuilder.DropTable(
            name: "UsuariosOngs");

        migrationBuilder.DropTable(
            name: "UsuariosProveedores");
    }
}
