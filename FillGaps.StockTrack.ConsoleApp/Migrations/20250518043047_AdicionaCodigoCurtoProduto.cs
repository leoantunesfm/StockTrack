using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FillGaps.StockTrack.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCodigoCurtoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoCurto",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoCurto",
                table: "Produtos",
                column: "CodigoCurto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_CodigoCurto",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodigoCurto",
                table: "Produtos");
        }
    }
}
