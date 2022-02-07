using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.WebApi.ModelsViews
{
	public class ResultadoPaginadoModelView<T> 
	{
		public IEnumerable<T> Itens { get; set; }
		public int PaginaAtual { get; set; }
		public int PaginaTamanho { get; set; }
		public int QuantidadeTotal { get; set; }
		public int TotalPaginas { get; set; }
	}
}
