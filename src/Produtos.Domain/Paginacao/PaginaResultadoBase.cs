using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Paginacao
{
    public class PaginaResultadoBase
    {
        public int PaginaAtual { get; set; }
       public int PaginaContagem { get; set; }
      public int PaginaTamanho { get; set; }
        public int LinhaContagem { get; set; }

        public int PrimeiraLinhaPagina
        {

            get { return (PaginaAtual - 1) * PaginaTamanho + 1; }
        }

        public int UltimaLinhaPagina
        {
            get { return Math.Min(PaginaAtual * PaginaTamanho, LinhaContagem); }
        }
    }
}
