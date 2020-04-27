using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    /// <summary>
    /// Classe representa a tabela dos "TipoPagamento" na BD
    /// </summary>
    public class TipoPagamento
    {

        public TipoPagamento()
        {
            // inicializar a lista de compras
            ListaDeCompras = new HashSet<Compra>();
        }


        /// <summary>
        /// PK da tabela 
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição/identificação do Tipo de pagamento
        /// </summary>
        public string Descricao { get; set; }


        /// <summary>
        /// Lista as compras efetuadas com um TipoPagamento
        /// Um TipoPagamento tem uma coleção de Compras
        /// </summary>      
        public virtual ICollection<Compra> ListaDeCompras { get; set; } //TipoPagamento----->Compra

    }
}
