using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compras.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_OrdenDeCompra_IdOrdenCompra",
                table: "OrdenProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_Producto_IdProducto",
                table: "OrdenProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_OrdenDeCompra_IdOrdenCompra",
                table: "OrdenProducto",
                column: "IdOrdenCompra",
                principalTable: "OrdenDeCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_Producto_IdProducto",
                table: "OrdenProducto",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_OrdenDeCompra_IdOrdenCompra",
                table: "OrdenProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenProducto_Producto_IdProducto",
                table: "OrdenProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_OrdenDeCompra_IdOrdenCompra",
                table: "OrdenProducto",
                column: "IdOrdenCompra",
                principalTable: "OrdenDeCompra",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenProducto_Producto_IdProducto",
                table: "OrdenProducto",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Id");
        }
    }
}
