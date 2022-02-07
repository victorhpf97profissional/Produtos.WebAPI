using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Servicos
{
    public class FornecedorServico : IFornecedorServico
    {
        private IFornecedorRepositorio _repositorio;

        public FornecedorServico(IFornecedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Fornecedor> ObterFornecedor(int id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<List<Fornecedor>> ObterTodosFornecedores()
        {
            return await _repositorio.ObterTodos();
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _repositorio.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {

            await _repositorio.Atualizar(fornecedor);

        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            await _repositorio.Excluir(fornecedor);

        }

        public void Dispose()
        {
            _repositorio.Dispose();


        }

    }
}
