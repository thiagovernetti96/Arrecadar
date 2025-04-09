using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area_Atuacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto_Perfil_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ong_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OngId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_Arrecadacao = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Valor_Arrecadado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagem_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanha_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atualizacao_Campanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atualizacao_Campanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atualizacao_Campanha_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    Valor_Doado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Metodo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atualizacao_Campanha_CampanhaId",
                table: "Atualizacao_Campanha",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_OngId",
                table: "Campanha",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_CampanhaId",
                table: "Doacao",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ong_UsuarioId",
                table: "Ong",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atualizacao_Campanha");

            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "Campanha");

            migrationBuilder.DropTable(
                name: "Ong");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
