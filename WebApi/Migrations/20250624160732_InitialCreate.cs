using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos_Guarco",
                columns: table => new
                {
                    id_documento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codigo = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    tipo = table.Column<string>(type: "TEXT", nullable: false),
                    nombre_area = table.Column<string>(type: "TEXT", nullable: false),
                    documento = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha_inicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fecha_finalizacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fecha_revision_inicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fecha_revision_finalizacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Fecha_aprobacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos_Guarco", x => x.id_documento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos_Guarco");
        }
    }
}
