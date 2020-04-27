using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class Compra
    {

        public Compra()
        {
            // inicializar a lista de produtos comprados
            ListaDeProdutosComprados = new HashSet<Produto>();
        }

        /// <summary>
        /// PK da tabela Compra
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Data da compra do Produto
        /// </summary>
        public DateTime DataCompra { get; set; }

        /// <summary>
        /// Data da entrega do Produto
        /// </summary>
        public DateTime DataEntrega { get; set; }

        /// <summary>
        /// Morada do Cliente para entrega do Produto
        /// </summary>
        public string MoradaEntrega { get; set; }

        /// <summary>
        /// Código Postal do Cliente para entrega do Produto
        /// </summary>
        public string CodPostal { get; set; }


        /// <summary>
        /// FK para a tabela Cliente
        /// </summary>
        [ForeignKey(nameof(Cliente))]
        public int ClienteFK { get; set; }
        public virtual Cliente Cliente { get; set; }

        /// <summary>
        /// FK para a tabela TipoPagamento
        /// </summary>
        [ForeignKey(nameof(TipoPagamento))]
        public int PagamentoFK { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }


        /// <summary>
        /// Lista das caracteristicas de um Produto
        /// </summary>      
        public virtual ICollection<Produto> ListaDeProdutosComprados { get; set; }
               
    }
}
