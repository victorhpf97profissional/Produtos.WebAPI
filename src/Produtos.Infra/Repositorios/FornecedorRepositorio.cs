using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private DbContexto Contexto { get; set; }

        public FornecedorRepositorio(DbContexto contexto)
        {
            Contexto = contexto;
        }


        public async Task Adicionar(Fornecedor fornecedor)
        {
            Contexto.Add(fornecedor);
            await SaveChanges();
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            Contexto.Update(fornecedor);
            await SaveChanges();
        }

        public void Dispose()
        {
            Contexto?.Dispose();
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            Contexto.Remove(fornecedor);
            await SaveChanges();
        }

        public async Task<Fornecedor> ObterPorId(int id)
        {

            return await Contexto.Fornecedores.AsNoTracking().Include(a => a.Produtos).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            return await Contexto.Fornecedores.AsNoTracking().Include(a => a.Produtos).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }
       
    }
}
