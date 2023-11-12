using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPAI_Entrega3.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AudioMensajeOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    MensajeOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    NroOrden = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dni = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCelular = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInformacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInformacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "opcionLlamada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    AudioMensajeSubOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    MensajeSubOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opcionLlamada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_opcionLlamada_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubOpcionLlamada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    OpcionLlamadaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOpcionLlamada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubOpcionLlamada_opcionLlamada_OpcionLlamadaId",
                        column: x => x.OpcionLlamadaId,
                        principalTable: "opcionLlamada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Llamada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionOperador = table.Column<string>(type: "TEXT", nullable: false),
                    DetalleAccionRequerida = table.Column<string>(type: "TEXT", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EncuestaEnviada = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObservacionAuditor = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubOpcionLlamadaId = table.Column<int>(type: "INTEGER", nullable: true),
                    OpcionLlamadaId = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Llamada_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Llamada_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Llamada_SubOpcionLlamada_SubOpcionLlamadaId",
                        column: x => x.SubOpcionLlamadaId,
                        principalTable: "SubOpcionLlamada",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Llamada_opcionLlamada_OpcionLlamadaId",
                        column: x => x.OpcionLlamadaId,
                        principalTable: "opcionLlamada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Validacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AudioMensajeValidacion = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    NroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoInformacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpcionLlamadaId = table.Column<int>(type: "INTEGER", nullable: true),
                    SubOpcionLlamadaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validacion_SubOpcionLlamada_SubOpcionLlamadaId",
                        column: x => x.SubOpcionLlamadaId,
                        principalTable: "SubOpcionLlamada",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Validacion_TipoInformacion_TipoInformacionId",
                        column: x => x.TipoInformacionId,
                        principalTable: "TipoInformacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Validacion_opcionLlamada_OpcionLlamadaId",
                        column: x => x.OpcionLlamadaId,
                        principalTable: "opcionLlamada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CambioEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaHoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    LlamadaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CambioEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CambioEstado_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CambioEstado_Llamada_LlamadaId",
                        column: x => x.LlamadaId,
                        principalTable: "Llamada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InformacionCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatoAValidar = table.Column<string>(type: "TEXT", nullable: false),
                    ValidacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoInformacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacionCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformacionCliente_TipoInformacion_TipoInformacionId",
                        column: x => x.TipoInformacionId,
                        principalTable: "TipoInformacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformacionCliente_Validacion_ValidacionId",
                        column: x => x.ValidacionId,
                        principalTable: "Validacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CambioEstado_EstadoId",
                table: "CambioEstado",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CambioEstado_LlamadaId",
                table: "CambioEstado",
                column: "LlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_ClienteId",
                table: "InformacionCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_TipoInformacionId",
                table: "InformacionCliente",
                column: "TipoInformacionId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_ValidacionId",
                table: "InformacionCliente",
                column: "ValidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_ClienteId",
                table: "Llamada",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_EstadoId",
                table: "Llamada",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_OpcionLlamadaId",
                table: "Llamada",
                column: "OpcionLlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_SubOpcionLlamadaId",
                table: "Llamada",
                column: "SubOpcionLlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_opcionLlamada_CategoriaId",
                table: "opcionLlamada",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOpcionLlamada_OpcionLlamadaId",
                table: "SubOpcionLlamada",
                column: "OpcionLlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_OpcionLlamadaId",
                table: "Validacion",
                column: "OpcionLlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_SubOpcionLlamadaId",
                table: "Validacion",
                column: "SubOpcionLlamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_TipoInformacionId",
                table: "Validacion",
                column: "TipoInformacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CambioEstado");

            migrationBuilder.DropTable(
                name: "InformacionCliente");

            migrationBuilder.DropTable(
                name: "Llamada");

            migrationBuilder.DropTable(
                name: "Validacion");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "SubOpcionLlamada");

            migrationBuilder.DropTable(
                name: "TipoInformacion");

            migrationBuilder.DropTable(
                name: "opcionLlamada");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
