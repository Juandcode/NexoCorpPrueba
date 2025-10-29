using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class UpdateCostoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Costo",
                table: "ExpProductos",
                newName: "Precio");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "ErpProductos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "ExpProductos",
                newName: "Costo");

            migrationBuilder.AlterColumn<int>(
                name: "Costo",
                table: "ErpProductos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
