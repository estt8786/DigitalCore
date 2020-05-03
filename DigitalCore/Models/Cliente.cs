using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class Cliente
    {
        public Cliente()
        {
            // inicializar a lista de compras
            ListaCompras = new HashSet<Compra>();
        }

        /// <summary>
        /// PK da tabela
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Display(Name = "Nome do cliente a ser usado na faturação")]
        [Required(ErrorMessage = "Introduza um nome válido.")]
        [StringLength(60, ErrorMessage = "O {0} poderá ter no máximo {1} caracteres.")]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        /// <summary>
        /// Login do utilizador
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password do utilizador
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Morada do utilizador
        /// </summary>
        public string Morada { get; set; }

        /// <summary>
        /// Código Postal do utilizador
        /// </summary>
        public string CodPostal { get; set; }

        /// <summary>
        /// Localidade do utilizador
        /// </summary>
        public string Localidade { get; set; }

        /// <summary>
        /// E-mail do utilizador que ativou a conta
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone do utilizador
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Número de Indentificação Fiscal do utilizador
        /// </summary>
        [Required(ErrorMessage = "O Número Indentificação Fiscal é de preeenchimento obrigatório")]
        [StringLength(9, ErrorMessage = "O {0} poderá ter no máximo {1} caracteres.")]
        [RegularExpression("[1-9][0-9]{8}", ErrorMessage = "Só aceita NIF válidos, com 9 digitos e introduzidos corretamente")]
        [Display(Name = "Nº Identificação Fiscal")]
        public string NIF { get; set; }



        /// <summary>
        /// Lista das Compras de um Cliente
        /// </summary>
        public virtual ICollection<Compra> ListaCompras { get; set; } // Cliente -----> Compras
    }
}
