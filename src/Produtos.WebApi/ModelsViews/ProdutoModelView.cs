using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Produtos.Domain.Models;

namespace Produtos.WebApi.ModelsViews
{
    public class ProdutoModelView
    {

        public ProdutoModelView() { }
   

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(150, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres", MinimumLength = 1)]
        [DisplayName("Descrição do produto")]
        public string Descricao { get; set; }
        public int SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        [HiddenInput]
        public int FornecedorId { get; set; }
        public FornecedorModelView Fornecedor { get; set; }
    }
}