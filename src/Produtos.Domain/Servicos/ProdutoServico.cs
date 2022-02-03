using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Servicos
{
    public class ProdutoServico: IProdutoServico
    {

          private IProdutoRepositorio _repositorio;

        public ProdutoServico(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Produto> ObterProduto(int id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<List<Produto>> ObterTodosProdutos()
        {
            return await _repositorio.ObterTodos();
        }

        public async Task Adicionar(Produto produto)
        {
            await _repositorio.Adicionar(produto);

        }

        public async Task Atualizar(Produto produto)
        {

             await _repositorio.Atualizar(produto);

        }

        public async Task Excluir(Produto produto)
        {

            await _repositorio.Excluir(produto);

        }

        public void Dispose()
        {

            _repositorio.Dispose();


        }

        public Task<Produto> ObterFornecedor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> ObterTodosFornecedores()
        {
            throw new NotImplementedException();
        }

        public Task Produto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
