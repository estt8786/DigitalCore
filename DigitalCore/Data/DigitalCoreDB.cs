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
