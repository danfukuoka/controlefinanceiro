using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Compra
    {
        public int CompraID { get; set; }
        public int CategoriaID { get; set; }

        public int EstabelecimentoID { get; set; }

        public DateTime Data { get; set; }

        public float Valor { get; set; }


        public virtual Categoria Categoria { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

    }
}