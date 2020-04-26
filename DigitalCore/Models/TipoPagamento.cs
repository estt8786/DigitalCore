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
        /// <summary>
        /// PK da tabela
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição/identificação do Tipo de pagamento
        /// </summary>
        public string Descricao { get; set; }
    }
}
