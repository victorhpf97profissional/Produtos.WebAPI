using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Paginacao
{
    public class PaginaParametros
    {
        public const int MaxPageSize = 50;
        public int NumeroPagina { get; set; } = 1;
        private int tamanhoPagina = 10;

        public int TamanhoPagina
        {
            get { return tamanhoPagina; }
            set { tamanhoPagina = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string Descricao { get; set; } = string.Empty;
        public int? SituacaoProduto { get; set; } = null;
    }
}
