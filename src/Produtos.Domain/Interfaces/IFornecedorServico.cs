using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces
{
    public interface IFornecedorServico: IDisposable
    {

         Task<Fornecedor> ObterFornecedor(int id);

         Task<List<Fornecedor>> ObterTodosFornecedores();

        Task Adicionar(Fornecedor fornecedor);

        Task Atualizar(Fornecedor fornecedor);

        Task Excluir(Fornecedor fornecedor);


    }
}
