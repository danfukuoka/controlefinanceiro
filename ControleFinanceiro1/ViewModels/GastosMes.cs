using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.ViewModels
{
    public class GastosMes
    {
        public int GastosMesID { get; set; }
        public int Dia { get; set; }

        public int Mes { get; set; }
        public int Ano { get; set; }
        public float Valor { get; set; }
    }
}