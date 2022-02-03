using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos.Domain.Models;
using Produtos.Domain.Utils;

namespace Produtos.Domain.Interfaces
{

    public interface IProdutoServico: IDisposable

    {

        Task<Produto> ObterProduto(int id);

        Task<List<Produto>> ObterTodosProdutos();

        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Excluir(Produto produto);

    }
}
