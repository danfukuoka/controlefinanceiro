using ControleFinanceiro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro1.DAL
{
    public interface IEstabelecimentoRepository : IDisposable
    {
        IEnumerable<Estabelecimento> GetEstabelecimentos();
        Estabelecimento GetEstabelecimentoByID(int EstabelecimentoID);
        void InsertEstabelecimento(Estabelecimento estabelecimento);
        void DeleteEstabelecimento(int EstabelecimentoID);
        void UpdateEstabelecimento(Estabelecimento estabelecimento);
        void SaveEstabelecimento();
    }
}