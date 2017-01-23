using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public DateTime DataHora { get; set; }
        public string Operacao { get; set; }

        public string Identificacao { get; set; }

    }
}