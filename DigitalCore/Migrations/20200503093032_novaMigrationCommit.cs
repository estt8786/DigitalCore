using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCore.Migrations
{
    public partial class novaMigrationCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas", x => x.ID);
                });

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
                name: "Produto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "Caracteristicas",
                columns: new[] { "ID", "Designacao" },
                values: new object[,]
                {
                    { 1, "Processador Intel i7 9700, 16GB RAM, Disco HDD 2TB, Grádica nVidia4GB, Windows10 Home" },
                    { 20, "Português 106 Teclas USB" },
                    { 18, "Intel i7 8700" },
                    { 17, "2GB" },
                    { 16, "AMD Radeon 520" },
                    { 15, "1TB" },
                    { 14, "8GB" },
                    { 13, "2,40GHz" },
                    { 12, "Intel i5" },
                    { 11, "Intel i5 8250U" },
                    { 19, "Intel i5 8250U" },
                    { 9, "240" },
                    { 8, "512" },
                    { 7, "3GB" },
                    { 6, "NVIDIA® GeForce® GTX 1060" },
                    { 5, "HD 23pol. 1080x720" },
                    { 4, "FULL HD 24pol. 1920x1080" },
                    { 3, "Processador Intel i3 5700, 4GB RAM, Disco HDD 500GB, Grádica nVidia1GB, Windows10 Home" },
                    { 2, "Processador Intel i5 7500, 8GB RAM, Disco HDD 1TB, Grádica nVidia2GB, Windows10 Home" },
                    { 10, "120" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ID", "CodPostal", "Email", "Localidade", "Morada", "NIF", "Nome", "Password", "Telefone", "Username" },
                values: new object[,]
                {
                    { 6, "2300-844", "msantos@sapo.pt", "Tomar", "Rua Oliveira Gaio, Nº275", "128573957", "Marta Santos", "231", "249839258", "msantos" },
                    { 4, "2300-743", "jsilva@gmail.pt", "Tomar", "Rua da Alcântara, Nº142", "201482693", "João Silva", "132", "249538247", "jsilva" },
                    { 5, "2300-235", "tpinheiro@hotmail.com", "Tomar", "Rua D. Pedro, Nº11", "159385395", "Teresa Pinheiro", "312", "249823953", "tpinheiro" },
                    { 2, "2300-538", "pconceicao@yahoo.com", "Tomar", "Rua João Torres, Nº94", "115836783", "Pedro Conceição", "213", "249765638", "pconceicaor" },
                    { 1, "2300-243", "msousa@gmail.com", "Tomar", "Rua do Comércio, Nº18", "115347923", "Miguel Sousa", "123", "249123456", "msousa" },
                    { 3, "2300-623", "misabel@sapo.pt", "Tomar", "Praça do Bom Jardim, Nº25", "102385734", "Maria Isabel", "321", "249654321", "misabel" }
                });

            migrationBuilder.InsertData(
                table: "TipoProduto",
                columns: new[] { "ID", "Descricao" },
                values: new object[,]
                {
                    { 11, "Teclado" },
                    { 1, "Computador Desktop" },
                    { 2, "Monitor" },
                    { 3, "Portátil" },
                    { 4, "Tablet" },
                    { 5, "Disco" },
                    { 6, "Memória RAM" },
                    { 7, "Placa Gráfica" },
                    { 8, "Impressora" },
                    { 9, "Pen USB" },
                    { 10, "Rato" },
                    { 12, "Processador" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "ID", "ClienteFK", "CodPostal", "DataCompra", "DataEntrega", "MoradaEntrega", "TipoPagamento" },
                values: new object[,]
                {
                    { 1, 1, "2300-453", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Amorim Rosa, Nº213", "Cartão de Crédito" },
                    { 4, 1, "2300-856", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua José Raimundo Rineiro, Nº54", "Referência Multibanco" },
                    { 5, 2, "2300-185", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Serpa Pinto, Nº97", "Transferência Bancária" },
                    { 2, 3, "2300-745", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Av. Dr. Egas Moniz, Nº14", "PayPal" },
                    { 6, 4, "2300-743", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua da Alcântara, Nº142", "Transferência Bancária" },
                    { 3, 6, "2300-345", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua 13 de Fevereiro, Nº28", "Referência Multibanco" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "ID", "CompraFK", "Descricao", "IVA", "Marca", "Modelo", "NumSerie", "Preco", "TipoProdutoFK" },
                values: new object[,]
                {
                    { 1, 1, "HP Omen 880-106Np", 23.0, "HP", "Omen 880", "123456789", 1200.0, 1 },
                    { 2, 1, "Toshiba TR200 3D TLC SATA III", 23.0, "Toshiba", "TR200", "123456790", 55.0, 5 },
                    { 5, 4, "Samsung 500GB EVO 850", 23.0, "Samsung", "EVO 850", "123456793", 125.0, 5 },
                    { 6, 5, "Kingston 120GB SSD A400 SATA III", 23.0, "Kingston", "A400", "123456794", 35.0, 5 },
                    { 7, 5, "HP 15-bs109np", 23.0, "HP", "bs109np", "123456795", 550.0, 3 },
                    { 8, 5, "Asus Zenbook UX430UA-78DHDCB1", 23.0, "Asus", "UX430UA", "123456796", 1200.0, 3 },
                    { 3, 2, "Asus ROG GR8II-T022Z Auta", 23.0, "Asus", "ROG GR8II", "123456791", 950.0, 1 },
                    { 4, 3, "Asus D320MT", 23.0, "Asus", "D320MT", "123456792", 600.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "CaracteristicasProduto",
                columns: new[] { "ID", "CaracteristicasFK", "ProdutoFK", "Valor" },
                values: new object[,]
                {
                    { 4, 3, 1, "599,90" },
                    { 3, 3, 3, "698,90" },
                    { 2, 2, 3, "999,90" },
                    { 1, 1, 3, "1699,00" },
                    { 7, 6, 7, "89,00" },
                    { 5, 4, 2, "249,90" },
                    { 6, 5, 2, "199,90" }
                });

            migrationBuilder.InsertData(
                table: "Imagem",
                columns: new[] { "ID", "NomeImagem", "ProdutoFK" },
                values: new object[,]
                {
                    { 3, "discossd01-01.jpg", 2 },
                    { 6, "computador02-02.jpg", 3 },
                    { 5, "computador02-01.jpg", 3 },
                    { 1, "computador01-01.jpg", 1 },
                    { 2, "computador01-02.jpg", 1 },
                    { 16, "portatil02-02", 8 },
                    { 15, "portatil02-01", 8 },
                    { 14, "portatil01-02", 7 },
                    { 7, "computador03-01.jpg", 4 },
                    { 12, "discossd03-02.jpg", 6 },
                    { 11, "discossd03-01.jpg", 6 },
                    { 10, "discossd02-02.jpg", 5 },
                    { 9, "discossd02-01.jpg", 5 },
                    { 4, "discossd01-02.jpg", 2 },
                    { 13, "portatil01-01", 7 },
                    { 8, "computador03-02.jpg", 4 }
                });

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
