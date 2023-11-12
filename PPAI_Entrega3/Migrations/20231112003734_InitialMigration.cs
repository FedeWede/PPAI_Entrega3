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
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dni = table.Column<string>(type: "TEXT", nullable: false),
                    nombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    numeroCelular = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "TipoInformacion",
                columns: table => new
                {
                    idTipoInformacion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInformacion", x => x.idTipoInformacion);
                });

            migrationBuilder.CreateTable(
                name: "CambioEstado",
                columns: table => new
                {
                    idCambioEstado = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fechaHoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estadoidEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    LlamadaidLlamada = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CambioEstado", x => x.idCambioEstado);
                    table.ForeignKey(
                        name: "FK_CambioEstado_Estado_estadoidEstado",
                        column: x => x.estadoidEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    audioMensajeOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    mensajeOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    nroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    opcionLlamadaidOpcionLlamada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "InformacionCliente",
                columns: table => new
                {
                    idInformacionCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    datoAValidar = table.Column<string>(type: "TEXT", nullable: false),
                    validacionidValidacion = table.Column<int>(type: "INTEGER", nullable: false),
                    tipoInformacionidTipoInformacion = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionCliente", x => x.idInformacionCliente);
                    table.ForeignKey(
                        name: "FK_InformacionCliente_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_InformacionCliente_TipoInformacion_tipoInformacionidTipoInformacion",
                        column: x => x.tipoInformacionidTipoInformacion,
                        principalTable: "TipoInformacion",
                        principalColumn: "idTipoInformacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Llamada",
                columns: table => new
                {
                    idLlamada = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcionOperador = table.Column<string>(type: "TEXT", nullable: false),
                    detalleAccionRequerida = table.Column<string>(type: "TEXT", nullable: false),
                    duracion = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    encuestaEnviada = table.Column<bool>(type: "INTEGER", nullable: false),
                    observacionAuditor = table.Column<string>(type: "TEXT", nullable: false),
                    clienteIdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    subOpcionLlamadaidSubOpcionLLamada = table.Column<int>(type: "INTEGER", nullable: false),
                    opcionLlamadaidOpcionLlamada = table.Column<int>(type: "INTEGER", nullable: false),
                    estadoidEstado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamada", x => x.idLlamada);
                    table.ForeignKey(
                        name: "FK_Llamada_Cliente_clienteIdCliente",
                        column: x => x.clienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Llamada_Estado_estadoidEstado",
                        column: x => x.estadoidEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opcionLlamada",
                columns: table => new
                {
                    idOpcionLlamada = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    audioMensajeSubOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    mensajeSubOpciones = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    nroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    subOpcionLlamadaidSubOpcionLLamada = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaidCategoria = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opcionLlamada", x => x.idOpcionLlamada);
                    table.ForeignKey(
                        name: "FK_opcionLlamada_Categoria_CategoriaidCategoria",
                        column: x => x.CategoriaidCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                });

            migrationBuilder.CreateTable(
                name: "SubOpcionLlamada",
                columns: table => new
                {
                    idSubOpcionLLamada = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    nroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    OpcionLlamadaidOpcionLlamada = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOpcionLlamada", x => x.idSubOpcionLLamada);
                    table.ForeignKey(
                        name: "FK_SubOpcionLlamada_opcionLlamada_OpcionLlamadaidOpcionLlamada",
                        column: x => x.OpcionLlamadaidOpcionLlamada,
                        principalTable: "opcionLlamada",
                        principalColumn: "idOpcionLlamada");
                });

            migrationBuilder.CreateTable(
                name: "Validacion",
                columns: table => new
                {
                    idValidacion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    audioMensajeValidacion = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    nroOrden = table.Column<int>(type: "INTEGER", nullable: false),
                    tipoInformacionidTipoInformacion = table.Column<int>(type: "INTEGER", nullable: false),
                    OpcionLlamadaidOpcionLlamada = table.Column<int>(type: "INTEGER", nullable: true),
                    SubOpcionLlamadaidSubOpcionLLamada = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacion", x => x.idValidacion);
                    table.ForeignKey(
                        name: "FK_Validacion_SubOpcionLlamada_SubOpcionLlamadaidSubOpcionLLamada",
                        column: x => x.SubOpcionLlamadaidSubOpcionLLamada,
                        principalTable: "SubOpcionLlamada",
                        principalColumn: "idSubOpcionLLamada");
                    table.ForeignKey(
                        name: "FK_Validacion_TipoInformacion_tipoInformacionidTipoInformacion",
                        column: x => x.tipoInformacionidTipoInformacion,
                        principalTable: "TipoInformacion",
                        principalColumn: "idTipoInformacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Validacion_opcionLlamada_OpcionLlamadaidOpcionLlamada",
                        column: x => x.OpcionLlamadaidOpcionLlamada,
                        principalTable: "opcionLlamada",
                        principalColumn: "idOpcionLlamada");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CambioEstado_estadoidEstado",
                table: "CambioEstado",
                column: "estadoidEstado");

            migrationBuilder.CreateIndex(
                name: "IX_CambioEstado_LlamadaidLlamada",
                table: "CambioEstado",
                column: "LlamadaidLlamada");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_opcionLlamadaidOpcionLlamada",
                table: "Categoria",
                column: "opcionLlamadaidOpcionLlamada");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_ClienteIdCliente",
                table: "InformacionCliente",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_tipoInformacionidTipoInformacion",
                table: "InformacionCliente",
                column: "tipoInformacionidTipoInformacion");

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCliente_validacionidValidacion",
                table: "InformacionCliente",
                column: "validacionidValidacion");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_clienteIdCliente",
                table: "Llamada",
                column: "clienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_estadoidEstado",
                table: "Llamada",
                column: "estadoidEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_opcionLlamadaidOpcionLlamada",
                table: "Llamada",
                column: "opcionLlamadaidOpcionLlamada");

            migrationBuilder.CreateIndex(
                name: "IX_Llamada_subOpcionLlamadaidSubOpcionLLamada",
                table: "Llamada",
                column: "subOpcionLlamadaidSubOpcionLLamada");

            migrationBuilder.CreateIndex(
                name: "IX_opcionLlamada_CategoriaidCategoria",
                table: "opcionLlamada",
                column: "CategoriaidCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_opcionLlamada_subOpcionLlamadaidSubOpcionLLamada",
                table: "opcionLlamada",
                column: "subOpcionLlamadaidSubOpcionLLamada");

            migrationBuilder.CreateIndex(
                name: "IX_SubOpcionLlamada_OpcionLlamadaidOpcionLlamada",
                table: "SubOpcionLlamada",
                column: "OpcionLlamadaidOpcionLlamada");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_OpcionLlamadaidOpcionLlamada",
                table: "Validacion",
                column: "OpcionLlamadaidOpcionLlamada");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_SubOpcionLlamadaidSubOpcionLLamada",
                table: "Validacion",
                column: "SubOpcionLlamadaidSubOpcionLLamada");

            migrationBuilder.CreateIndex(
                name: "IX_Validacion_tipoInformacionidTipoInformacion",
                table: "Validacion",
                column: "tipoInformacionidTipoInformacion");

            migrationBuilder.AddForeignKey(
                name: "FK_CambioEstado_Llamada_LlamadaidLlamada",
                table: "CambioEstado",
                column: "LlamadaidLlamada",
                principalTable: "Llamada",
                principalColumn: "idLlamada");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_opcionLlamada_opcionLlamadaidOpcionLlamada",
                table: "Categoria",
                column: "opcionLlamadaidOpcionLlamada",
                principalTable: "opcionLlamada",
                principalColumn: "idOpcionLlamada",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionCliente_Validacion_validacionidValidacion",
                table: "InformacionCliente",
                column: "validacionidValidacion",
                principalTable: "Validacion",
                principalColumn: "idValidacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Llamada_SubOpcionLlamada_subOpcionLlamadaidSubOpcionLLamada",
                table: "Llamada",
                column: "subOpcionLlamadaidSubOpcionLLamada",
                principalTable: "SubOpcionLlamada",
                principalColumn: "idSubOpcionLLamada",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Llamada_opcionLlamada_opcionLlamadaidOpcionLlamada",
                table: "Llamada",
                column: "opcionLlamadaidOpcionLlamada",
                principalTable: "opcionLlamada",
                principalColumn: "idOpcionLlamada",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_opcionLlamada_SubOpcionLlamada_subOpcionLlamadaidSubOpcionLLamada",
                table: "opcionLlamada",
                column: "subOpcionLlamadaidSubOpcionLLamada",
                principalTable: "SubOpcionLlamada",
                principalColumn: "idSubOpcionLLamada",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_opcionLlamada_opcionLlamadaidOpcionLlamada",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_SubOpcionLlamada_opcionLlamada_OpcionLlamadaidOpcionLlamada",
                table: "SubOpcionLlamada");

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
                name: "TipoInformacion");

            migrationBuilder.DropTable(
                name: "opcionLlamada");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "SubOpcionLlamada");
        }
    }
}
