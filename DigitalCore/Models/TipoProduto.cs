using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class TipoProduto
    {

        public TipoProduto()
        {
            // inicializar a lista de produtos comprados
            ListaDeProdutos = new HashSet<Produto>();
        }

        /// <summary>
        /// PK da tabela TipoProduto
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição/identificação do Tipo de Produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Lista os Produtos de um TipoProdutos
        /// </summary>      
        public virtual ICollection<Produto> ListaDeProdutos { get; set; } //Produtos----->TipoProdutos

    }
}
