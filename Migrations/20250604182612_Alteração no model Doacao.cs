using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãonomodelDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbacatePayBillId",
                table: "Doacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbacatePayUrl",
                table: "Doacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbacatePayBillId",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "AbacatePayUrl",
                table: "Doacao");
        }
    }
}
