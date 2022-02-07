using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos.Domain.Models;
using Produtos.Domain.Paginacao;

namespace Produtos.Domain.Interfaces
{

    public interface IProdutoServico: IDisposable

    {

        Task<Produto> ObterProduto(int id);

        Task<List<Produto>> ObterTodosProdutos();
        Task<Paginacao<Produto>> ObterPorPaginacao(PaginaParametros paginaParametros);

        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Excluir(Produto produto);

    }
}
