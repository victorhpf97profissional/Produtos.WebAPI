using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Paginacao
{
    public  class Paginacao<T> : List<T>
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaTamanho { get; set; }
        public int QuantidadeTotal { get; set; }

        public Paginacao(List<T> itens, int quantidade, int paginaNumero, int pageSize)
        {
            QuantidadeTotal = quantidade;
            PaginaTamanho = pageSize;
            PaginaAtual = paginaNumero;
            TotalPaginas = (int)Math.Ceiling(quantidade / (double)pageSize);
       


            this.AddRange(itens);
        }

        public static async Task<Paginacao<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)

        {

            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Paginacao<T>(items, count, pageNumber, pageSize);
        }
    }
}
