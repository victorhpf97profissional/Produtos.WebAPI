using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Produtos.Domain.Models;

namespace Produtos.WebApi.ModelsViews
{
    public class FornecedorModelView
    {
        public FornecedorModelView() { }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(150, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres", MinimumLength = 1)]
        [DisplayName("Descrição do fornecedor")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(14, ErrorMessage = "O {0} deve ter {2} caracteres", MinimumLength = 14)]
        public string Cnpj { get; set; }

    }
}