using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class ConfigureTiposProductos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos");

            migrationBuilder.DropIndex(
                name: "IX_ExpProductos_IdTipoProducto",
                table: "ExpProductos");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTipoProducto",
                table: "ExpProductos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ExpProductos_IdTipoProducto",
                table: "ExpProductos",
                column: "IdTipoProducto",
                unique: true,
                filter: "[IdTipoProducto] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos",
                column: "IdTipoProducto",
                principalTable: "TiposProductos",
                principalColumn: "IdTipoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos");

            migrationBuilder.DropIndex(
                name: "IX_ExpProductos_IdTipoProducto",
                table: "ExpProductos");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTipoProducto",
                table: "ExpProductos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpProductos_IdTipoProducto",
                table: "ExpProductos",
                column: "IdTipoProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpProductos_TiposProductos_IdTipoProducto",
                table: "ExpProductos",
                column: "IdTipoProducto",
                principalTable: "TiposProductos",
                principalColumn: "IdTipoProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
