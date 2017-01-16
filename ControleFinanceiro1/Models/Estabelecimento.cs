using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Estabelecimento
    {
        public int EstabelecimentoID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}