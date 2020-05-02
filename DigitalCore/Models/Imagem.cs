﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Models
{
    public class Imagem
    {

        /// <summary>
        /// PK da tabela Imagem
        /// </summary>
        [Key] // Anotação que força este atributo a ser PK. Mas, não seria necessário, pq o atributo chama-se "ID"
        public int ID { set; get; }

        /// <summary>
        /// Descrição/identificação da imagem
        /// </summary>
        public string NomeImagem { get; set; }


        /// <summary>
        /// FK para a tabela Produto
        /// </summary>
        [ForeignKey(nameof(Produto))]
        public int ProdutoFK { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
