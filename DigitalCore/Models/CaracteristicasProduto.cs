using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    /// <summary>
    /// Classe de relacionamento de M para N entre as classes Produto e Caracteristicas
    /// </summary>
    public class CaracteristicasProduto
    {
        /// <summary>
        /// PK da tabela CaracteristicasProduto
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição/identificação do Valor do Produto com as Características
        /// </summary>
        public string Valor { get; set; }


        /// <summary>
        /// FK para a tabela Produto
        /// </summary>
        [ForeignKey(nameof(Produto))]
        public int ProdutoFK { get; set; }
        public virtual Produto Produto { get; set; }


        /// <summary>
        /// FK para a tabela Caracteristicas
        /// </summary>
        [ForeignKey(nameof(Caracteristicas))]
        public int CaracteristicasFK { get; set; }
        public virtual Caracteristicas Caracteristicas { get; set; }

    }
}
