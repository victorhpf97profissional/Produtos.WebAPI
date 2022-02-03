using Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces
{
    public interface IFornecedorRepositorio : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task<Fornecedor> ObterPorId(int id);
        Task<List<Fornecedor>> ObterTodos();
        Task Atualizar(Fornecedor fornecedor);
        Task Excluir(int id);
        Task<int> SaveChanges();

        }

    }
