using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class Caracteristicas
    {

        public Caracteristicas()
        {
            // inicializar a lista de características de um 'TipoProduto'
            ListaDeProdutos = new HashSet<Produto>();
        }

        /// <summary>
        /// PK da tabela Características
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Designação do Produto
        /// </summary>
        public string Designacao { get; set; }

        /// <summary>
        /// Função do Produto
        /// </summary>
        public string Funcao { get; set; }


        /// <summary>
        /// FK para a tabela TipoProduto
        /// </summary>
        [ForeignKey(nameof(TipoProduto))]
        public int TipoProdutoFK { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }


        /// <summary>
        /// Lista das caracteristicas de um Produto
        /// </summary>      
        public virtual ICollection<Produto> ListaDeProdutos { get; set; }

    }
}
