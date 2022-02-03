using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Models
{
    public class Fornecedor:EntidadeBase
    {
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

    }
}
