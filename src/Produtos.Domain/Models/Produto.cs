using System;

namespace Produtos.Domain.Models
{
    public class Produto:EntidadeBase
    {
        public int FornecedorId { get; set; }
        public string Descricao { get; set; }
        public Situacao SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Fornecedor Fornecedor { get; set; }


    }
}