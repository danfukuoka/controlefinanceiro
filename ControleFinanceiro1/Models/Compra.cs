using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Compra
    {
        public int CompraID { get; set; }
        [DisplayName("Categoria")]
        public int CategoriaID { get; set; }

        [DisplayName("Estabelecimento")]
        public int EstabelecimentoID { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Preencha esse campo.")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}",ApplyFormatInEditMode = true)]
        [RegularExpression(@"^-?\d+(\.\d{2})?$", ErrorMessage = "Valor Inválido. O padrão é xx.xx")]
        [Required(ErrorMessage = "Preencha esse campo.")]
        public float Valor { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

    }
}