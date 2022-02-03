using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Models
{
    public class EntidadeBase
    {
        public int Id { get; set; }


        public EntidadeBase()
        {
            Id = -1;
        }
    }
}
