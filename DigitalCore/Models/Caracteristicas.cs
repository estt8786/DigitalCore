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
            ListaDeProdutosCaracteristicas = new HashSet<CaracteristicasProduto>();
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
        /// Lista das caracteristicas/Produto de um Produto
        /// </summary>      
        public virtual ICollection<CaracteristicasProduto> ListaDeProdutosCaracteristicas { get; set; }

    }
}
