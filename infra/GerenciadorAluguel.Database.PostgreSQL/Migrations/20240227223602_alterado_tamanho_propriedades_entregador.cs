using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorAluguel.Database.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class alteradotamanhopropriedadesentregador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroCnh",
                table: "Entregador",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Entregador",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Entregador_Cnpj",
                table: "Entregador",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entregador_NumeroCnh",
                table: "Entregador",
                column: "NumeroCnh",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entregador_Cnpj",
                table: "Entregador");

            migrationBuilder.DropIndex(
                name: "IX_Entregador_NumeroCnh",
                table: "Entregador");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCnh",
                table: "Entregador",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Entregador",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14);
        }
    }
}
