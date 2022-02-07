using AutoMapper;
using Produtos.Domain.Models;
using Produtos.WebApi.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.WebApi.AutoMapper
{
    public class AutoMapperConfig: Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorModelView>().ReverseMap();
            CreateMap<Produto, ProdutoModelView>().ReverseMap();
        }
    }
}
