using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Domain.Paginacao;
using Produtos.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private DbContexto Contexto { get; set; }

        public ProdutoRepositorio(DbContexto contexto)
        {
            Contexto = contexto;
        }

        public async Task Adicionar(Produto produto)
        {
            Contexto.Add(produto);
            await SaveChanges();
        }

        public async Task Atualizar(Produto produto)
        {
            Contexto.Update(produto);
            await SaveChanges();
        }

        public async Task Excluir(Produto produto)
        {
            Contexto.Remove(produto);
            await SaveChanges();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await Contexto.Produtos.AsNoTracking().Include(a => a.Fornecedor).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Produto>> ObterTodos()
        {
            return await Contexto.Produtos.AsNoTracking().Where(a => a.SituacaoProduto == 1).Include(a => a.Fornecedor).ToListAsync();
        }

        public async Task<Paginacao<Produto>> ObterPorPaginacao(PaginaParametros paginaParametros)
        {
            IQueryable<Produto> query = Contexto.Produtos;

            query = query.AsNoTracking().Include(a => a.Fornecedor);

            if (!string.IsNullOrEmpty(paginaParametros.Descricao))
            {
                query = query.Where(produto => produto.Descricao.ToUpper().Contains(paginaParametros.Descricao.ToUpper()));

            }

            if (paginaParametros.SituacaoProduto != null)
            {
                query = query.Where(produto => produto.SituacaoProduto == paginaParametros.SituacaoProduto);
            }
            else
            {
                query = query.Where(a => a.SituacaoProduto == 1);
            }
            query = query.OrderBy(a => a.Id);

            return await Paginacao<Produto>.CreateAsync(query, paginaParametros.NumeroPagina, paginaParametros.TamanhoPagina);
        }
             public void Dispose()
        {
            Contexto?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }

    }
}
