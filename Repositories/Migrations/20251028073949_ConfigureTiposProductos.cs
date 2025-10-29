using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class ConfigureTiposProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdTipoProducto",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TiposProductos",
                columns: table => new
                {
                    IdTipoProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProductos", x => x.IdTipoProducto);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdTipoProducto",
                table: "Productos",
                column: "IdTipoProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TiposProductos_IdTipoProducto",
                table: "Productos",
                column: "IdTipoProducto",
                principalTable: "TiposProductos",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TiposProductos_IdTipoProducto",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "TiposProductos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdTipoProducto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdTipoProducto",
                table: "Productos");
        }
    }
}
