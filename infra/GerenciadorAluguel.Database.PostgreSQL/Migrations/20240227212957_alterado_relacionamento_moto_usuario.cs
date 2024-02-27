using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorAluguel.Database.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class alteradorelacionamentomotousuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Moto_idUsuario",
                table: "Moto");

            migrationBuilder.CreateIndex(
                name: "IX_Moto_idUsuario",
                table: "Moto",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Moto_Placa",
                table: "Moto",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Moto_idUsuario",
                table: "Moto");

            migrationBuilder.DropIndex(
                name: "IX_Moto_Placa",
                table: "Moto");

            migrationBuilder.CreateIndex(
                name: "IX_Moto_idUsuario",
                table: "Moto",
                column: "idUsuario",
                unique: true);
        }
    }
}
