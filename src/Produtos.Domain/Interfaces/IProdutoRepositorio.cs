﻿using Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces
{
    public interface IProdutoRepositorio : IDisposable
    {
        Task Adicionar(Produto produto);
        Task<Produto> ObterPorId(int id);
        Task<List<Produto>> ObterTodos();
        Task Atualizar(Produto produto);
        Task Excluir(Produto produto);
        Task<int> SaveChanges();

    }

}
