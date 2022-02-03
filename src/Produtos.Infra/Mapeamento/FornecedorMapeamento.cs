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
    class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Descricao).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.Cnpj).IsRequired().HasColumnType("varchar(14)");
            builder.HasMany(a => a.Produtos).WithOne(a => a.Fornecedor).HasForeignKey(a=> a.FornecedorId);
            builder.ToTable("Fornecedores").Property(a=> a.Id).ValueGeneratedOnAdd();


        }
    }
}
