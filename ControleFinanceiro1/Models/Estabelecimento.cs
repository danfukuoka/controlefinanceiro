using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Estabelecimento
    {
        public int EstabelecimentoID { get; set; }
        [Required(ErrorMessage = "Preencha esse campo.")]
        public string Nome { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}