using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.Mapeamento
{
    class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Descricao).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.DataFabricacao).HasColumnType("datetime");
            builder.Property(a => a.DataValidade).HasColumnType("datetime");
            builder.Property(a => a.SituacaoProduto).HasColumnType("int(1)");
            builder.ToTable("Produtos").Property(a => a.Id).ValueGeneratedOnAdd();


        }
    }
}
