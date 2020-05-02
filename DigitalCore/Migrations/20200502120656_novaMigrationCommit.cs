using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCore.Migrations
{
    public partial class novaMigrationCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    Localidade = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    MoradaEntrega = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    TipoPagamento = table.Column<string>(nullable: true),
                    ClienteFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Compra_Cliente_ClienteFK",
                        column: x => x.ClienteFK,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true),
                    TipoProdutoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Caracteristicas_TipoProduto_TipoProdutoID",
                        column: x => x.TipoProdutoID,
                        principalTable: "TipoProduto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrição = table.Column<string>(nullable: true),
                    NumSerie = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
                    TipoProdutoFK = table.Column<int>(nullable: false),
                    CompraFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produto_Compra_CompraFK",
                        column: x => x.CompraFK,
                        principalTable: "Compra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoFK",
                        column: x => x.TipoProdutoFK,
                        principalTable: "TipoProduto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicasProduto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(nullable: true),
                    ProdutoFK = table.Column<int>(nullable: false),
                    CaracteristicasFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasProduto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaracteristicasProduto_Caracteristicas_CaracteristicasFK",
                        column: x => x.CaracteristicasFK,
                        principalTable: "Caracteristicas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaracteristicasProduto_Produto_ProdutoFK",
                        column: x => x.ProdutoFK,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeImagem = table.Column<string>(nullable: true),
                    ProdutoFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Imagem_Produto_ProdutoFK",
                        column: x => x.ProdutoFK,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracteristicas_TipoProdutoID",
                table: "Caracteristicas",
                column: "TipoProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasProduto_CaracteristicasFK",
                table: "CaracteristicasProduto",
                column: "CaracteristicasFK");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasProduto_ProdutoFK",
                table: "CaracteristicasProduto",
                column: "ProdutoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ClienteFK",
                table: "Compra",
                column: "ClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ProdutoFK",
                table: "Imagem",
                column: "ProdutoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CompraFK",
                table: "Produto",
                column: "CompraFK");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoFK",
                table: "Produto",
                column: "TipoProdutoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaracteristicasProduto");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
