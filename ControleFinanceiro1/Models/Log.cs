using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Log
    {
        public int LogID { get; set; }
        [DisplayName("Data e Hora")]
        public DateTime DataHora { get; set; }
        [DisplayName("Operação")]
        public string Operacao { get; set; }
        [DisplayName("Identificação")]
        public string Identificacao { get; set; }

    }
}