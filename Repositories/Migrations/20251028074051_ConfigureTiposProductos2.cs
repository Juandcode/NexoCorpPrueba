using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class ConfigureTiposProductos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TiposProductos_IdTipoProducto",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosCategorias_Productos_IdProducto",
                table: "ProductosCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "ExpProductos");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdTipoProducto",
                table: "ExpProductos",
                newName: "IX_ExpProductos_IdTipoProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpProductos",
                table: "ExpProductos",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos",
                column: "IdTipoProducto",
                principalTable: "TiposProductos",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosCategorias_ExpProductos_IdProducto",
                table: "ProductosCategorias",
                column: "IdProducto",
                principalTable: "ExpProductos",
                principalColumn: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosCategorias_ExpProductos_IdProducto",
                table: "ProductosCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpProductos",
                table: "ExpProductos");

            migrationBuilder.RenameTable(
                name: "ExpProductos",
                newName: "Productos");

            migrationBuilder.RenameIndex(
                name: "IX_ExpProductos_IdTipoProducto",
                table: "Productos",
                newName: "IX_Productos_IdTipoProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TiposProductos_IdTipoProducto",
                table: "Productos",
                column: "IdTipoProducto",
                principalTable: "TiposProductos",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosCategorias_Productos_IdProducto",
                table: "ProductosCategorias",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto");
        }
    }
}
