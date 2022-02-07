using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Paginacao
{
    public class PaginaResultado<T> : PaginaResultadoBase where T : class
    {
        public IList<T> Resultados { get; set; }

        public PaginaResultado()
        {
            Resultados = new List<T>();
        }
    }
}
