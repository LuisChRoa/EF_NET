using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "pr_tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrioridadTarea = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pr_tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_pr_tarea_tb_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tb_categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pr_tarea_CategoriaId",
                table: "pr_tarea",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pr_tarea");

            migrationBuilder.DropTable(
                name: "tb_categoria");
        }
    }
}
