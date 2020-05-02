using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class Produto
    {

        public Produto()
        {
            // inicializar a lista de Características/Produto associados a um 'Produto'
            ListaDeCaracteristicasProduto = new HashSet<CaracteristicasProduto>();
        }

        /// <summary>
        /// PK da tabela
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        public string Descrição { get; set; }

        /// <summary>
        /// Número de série do Produto
        /// </summary>
        public string NumSerie { get; set; }

        /// <summary>
        /// Marca do Produto
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Modelo do Produto
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Preço do Produto
        /// </summary>
        public double Preco { get; set; }

        /// <summary>
        /// IVA a aplicar sobre Produto
        /// </summary>
        public double IVA { get; set; }


        /// <summary>
        /// FK para a tabela do TipoProduto
        /// </summary>
        [ForeignKey(nameof(TipoProduto))]
        public int TipoProdutoFK { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }

        /// <summary>
        /// FK para a tabela da Compra
        /// </summary>
        [ForeignKey(nameof(Compra))]
        public int CompraFK { get; set; }
        public virtual Compra Compra { get; set; }


        /// <summary>
        /// Lista das caracteristicas de um Produto
        /// </summary>      
        public virtual ICollection<CaracteristicasProduto> ListaDeCaracteristicasProduto { get; set; }
    }
}
