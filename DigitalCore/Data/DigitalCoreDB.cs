using DigitalCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Data
{
    public class DigitalCoreDB : DbContext
    {
        public DigitalCoreDB(DbContextOptions<DigitalCoreDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // insert DB seed
            modelBuilder.Entity<Cliente>().HasData(
               new Cliente { ID = 1, Nome = "Miguel Sousa", Username = "msousa", Password = "123", Morada = "Rua do Comércio, Nº18", CodPostal = "2300-243", Localidade = "Tomar", Email = "msousa@gmail.com", Telefone = "249123456", NIF = "115347923" },
               new Cliente { ID = 2, Nome = "Pedro Conceição", Username = "pconceicaor", Password = "213", Morada = "Rua João Torres, Nº94", CodPostal = "2300-538", Localidade = "Tomar", Email = "pconceicao@yahoo.com", Telefone = "249765638", NIF = "115836783" },
               new Cliente { ID = 3, Nome = "Maria Isabel", Username = "misabel", Password = "321", Morada = "Praça do Bom Jardim, Nº25", CodPostal = "2300-623", Localidade = "Tomar", Email = "misabel@sapo.pt", Telefone = "249654321", NIF = "102385734" },
               new Cliente { ID = 4, Nome = "João Silva", Username = "jsilva", Password = "132", Morada = "Rua da Alcântara, Nº142", CodPostal = "2300-743", Localidade = "Tomar", Email = "jsilva@gmail.pt", Telefone = "249538247", NIF = "201482693" },
               new Cliente { ID = 5, Nome = "Teresa Pinheiro", Username = "tpinheiro", Password = "312", Morada = "Rua D. Pedro, Nº11", CodPostal = "2300-235", Localidade = "Tomar", Email = "tpinheiro@hotmail.com", Telefone = "249823953", NIF = "159385395" },
               new Cliente { ID = 6, Nome = "Marta Santos", Username = "msantos", Password = "231", Morada = "Rua Oliveira Gaio, Nº275", CodPostal = "2300-844", Localidade = "Tomar", Email = "msantos@sapo.pt", Telefone = "249839258", NIF = "128573957" }
               );

            modelBuilder.Entity<Imagem>().HasData(
              new Imagem { ID = 1, NomeImagem = "computador01-01.jpg", ProdutoFK = 1 },
              new Imagem { ID = 2, NomeImagem = "computador01-02.jpg", ProdutoFK = 1 },
              new Imagem { ID = 3, NomeImagem = "discossd01-01.jpg", ProdutoFK = 2 },
              new Imagem { ID = 4, NomeImagem = "discossd01-02.jpg", ProdutoFK = 2 },
              new Imagem { ID = 5, NomeImagem = "computador02-01.jpg", ProdutoFK = 3 },
              new Imagem { ID = 6, NomeImagem = "computador02-02.jpg", ProdutoFK = 3 },
              new Imagem { ID = 7, NomeImagem = "computador03-01.jpg", ProdutoFK = 4 },
              new Imagem { ID = 8, NomeImagem = "computador03-02.jpg", ProdutoFK = 4 },
              new Imagem { ID = 9, NomeImagem = "discossd02-01.jpg", ProdutoFK = 5 },
              new Imagem { ID = 10, NomeImagem = "discossd02-02.jpg", ProdutoFK = 5 },
              new Imagem { ID = 11, NomeImagem = "discossd03-01.jpg", ProdutoFK = 6 },
              new Imagem { ID = 12, NomeImagem = "discossd03-02.jpg", ProdutoFK = 6 },
              new Imagem { ID = 13, NomeImagem = "portatil01-01", ProdutoFK = 7 },
              new Imagem { ID = 14, NomeImagem = "portatil01-02", ProdutoFK = 7 },
              new Imagem { ID = 15, NomeImagem = "portatil02-01", ProdutoFK = 8 },
              new Imagem { ID = 16, NomeImagem = "portatil02-02", ProdutoFK = 8 }
              );

            modelBuilder.Entity<TipoProduto>().HasData(
              new TipoProduto { ID = 1, Descricao = "Computador Desktop" },
              new TipoProduto { ID = 2, Descricao = "Monitor" },
              new TipoProduto { ID = 3, Descricao = "Portátil" },
              new TipoProduto { ID = 4, Descricao = "Tablet" },
              new TipoProduto { ID = 5, Descricao = "Disco" },
              new TipoProduto { ID = 6, Descricao = "Memória RAM" },
              new TipoProduto { ID = 7, Descricao = "Placa Gráfica" },
              new TipoProduto { ID = 8, Descricao = "Impressora" },
              new TipoProduto { ID = 9, Descricao = "Pen USB" },
              new TipoProduto { ID = 10, Descricao = "Rato" },
              new TipoProduto { ID = 11, Descricao = "Teclado" },
              new TipoProduto { ID = 12, Descricao = "Processador" }
              );

            modelBuilder.Entity<Caracteristicas>().HasData(
              new Caracteristicas { ID = 1, Designacao = "Processador Intel i7 9700, 16GB RAM, Disco HDD 2TB, Grádica nVidia4GB, Windows10 Home" },
              new Caracteristicas { ID = 2, Designacao = "Processador Intel i5 7500, 8GB RAM, Disco HDD 1TB, Grádica nVidia2GB, Windows10 Home" },
              new Caracteristicas { ID = 3, Designacao = "Processador Intel i3 5700, 4GB RAM, Disco HDD 500GB, Grádica nVidia1GB, Windows10 Home" },
              new Caracteristicas { ID = 4, Designacao = "FULL HD 24pol. 1920x1080" },
              new Caracteristicas { ID = 5, Designacao = "HD 23pol. 1080x720" },
              new Caracteristicas { ID = 6, Designacao = "NVIDIA® GeForce® GTX 1060" },
              new Caracteristicas { ID = 7, Designacao = "3GB" },
              new Caracteristicas { ID = 8, Designacao = "512" },
              new Caracteristicas { ID = 9, Designacao = "240" },
              new Caracteristicas { ID = 10, Designacao = "120" },
              new Caracteristicas { ID = 11, Designacao = "Intel i5 8250U" },
              new Caracteristicas { ID = 12, Designacao = "Intel i5" },
              new Caracteristicas { ID = 13, Designacao = "2,40GHz" },
              new Caracteristicas { ID = 14, Designacao = "8GB" },
              new Caracteristicas { ID = 15, Designacao = "1TB" },
              new Caracteristicas { ID = 16, Designacao = "AMD Radeon 520" },
              new Caracteristicas { ID = 17, Designacao = "2GB" },
              new Caracteristicas { ID = 18, Designacao = "Intel i7 8700" },
              new Caracteristicas { ID = 19, Designacao = "Intel i5 8250U" },
              new Caracteristicas { ID = 20, Designacao = "Português 106 Teclas USB" }
              );

            modelBuilder.Entity<Produto>().HasData(
              new Produto { ID = 1, NumSerie = "123456789", CompraFK = 1, TipoProdutoFK = 1, Marca = "HP", Modelo = "Omen 880", Descricao = "HP Omen 880-106Np", Preco = 1200, IVA = 23 },
              new Produto { ID = 2, NumSerie = "123456790", CompraFK = 1, TipoProdutoFK = 5, Marca = "Toshiba", Modelo = "TR200", Descricao = "Toshiba TR200 3D TLC SATA III", Preco = 55, IVA = 23 },
              new Produto { ID = 3, NumSerie = "123456791", CompraFK = 2, TipoProdutoFK = 1, Marca = "Asus", Modelo = "ROG GR8II", Descricao = "Asus ROG GR8II-T022Z Auta", Preco = 950, IVA = 23 },
              new Produto { ID = 4, NumSerie = "123456792", CompraFK = 3, TipoProdutoFK = 1, Marca = "Asus", Modelo = "D320MT", Descricao = "Asus D320MT", Preco = 600, IVA = 23 },
              new Produto { ID = 5, NumSerie = "123456793", CompraFK = 4, TipoProdutoFK = 5, Marca = "Samsung", Modelo = "EVO 850", Descricao = "Samsung 500GB EVO 850", Preco = 125, IVA = 23 },
              new Produto { ID = 6, NumSerie = "123456794", CompraFK = 5, TipoProdutoFK = 5, Marca = "Kingston", Modelo = "A400", Descricao = "Kingston 120GB SSD A400 SATA III", Preco = 35, IVA = 23 },
              new Produto { ID = 7, NumSerie = "123456795", CompraFK = 5, TipoProdutoFK = 3, Marca = "HP", Modelo = "bs109np", Descricao = "HP 15-bs109np", Preco = 550, IVA = 23 },
              new Produto { ID = 8, NumSerie = "123456796", CompraFK = 5, TipoProdutoFK = 3, Marca = "Asus", Modelo = "UX430UA", Descricao = "Asus Zenbook UX430UA-78DHDCB1", Preco = 1200, IVA = 23 }
              );

            modelBuilder.Entity<CaracteristicasProduto>().HasData(
              new CaracteristicasProduto { ID = 1, Valor = "1699,00", ProdutoFK = 3, CaracteristicasFK = 1 },
              new CaracteristicasProduto { ID = 2, Valor = "999,90", ProdutoFK = 3, CaracteristicasFK = 2 },
              new CaracteristicasProduto { ID = 3, Valor = "698,90", ProdutoFK = 3, CaracteristicasFK = 3 },
              new CaracteristicasProduto { ID = 4, Valor = "599,90", ProdutoFK = 1, CaracteristicasFK = 3 },
              new CaracteristicasProduto { ID = 5, Valor = "249,90", ProdutoFK = 2, CaracteristicasFK = 4 },
              new CaracteristicasProduto { ID = 6, Valor = "199,90", ProdutoFK = 2, CaracteristicasFK = 5 },
              new CaracteristicasProduto { ID = 7, Valor = "89,00", ProdutoFK = 7, CaracteristicasFK = 6 }

              );

            modelBuilder.Entity<Compra>().HasData(
               new Compra { ID = 1, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 1, TipoPagamento = "Cartão de Crédito", MoradaEntrega = "Rua Amorim Rosa, Nº213", CodPostal = "2300-453" },
               new Compra { ID = 2, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 3, TipoPagamento = "PayPal", MoradaEntrega = "Av. Dr. Egas Moniz, Nº14", CodPostal = "2300-745" },
               new Compra { ID = 3, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 6, TipoPagamento = "Referência Multibanco", MoradaEntrega = "Rua 13 de Fevereiro, Nº28", CodPostal = "2300-345" },
               new Compra { ID = 4, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 1, TipoPagamento = "Referência Multibanco", MoradaEntrega = "Rua José Raimundo Rineiro, Nº54", CodPostal = "2300-856" },
               new Compra { ID = 5, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 2, TipoPagamento = "Transferência Bancária", MoradaEntrega = "Rua Serpa Pinto, Nº97", CodPostal = "2300-185" },
               new Compra { ID = 6, DataCompra = new DateTime(2020, 05, 06), DataEntrega = new DateTime(2020, 05, 07), ClienteFK = 4, TipoPagamento = "Transferência Bancária", MoradaEntrega = "Rua da Alcântara, Nº142", CodPostal = "2300-743" }
               );
        }

        // adicionar as 'tabelas' à Base de Dados
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        public virtual DbSet<TipoProduto> TipoProduto { get; set; }
        public virtual DbSet<Caracteristicas> Caracteristicas { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<CaracteristicasProduto> CaracteristicasProduto { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }

    }
}
