﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}