using CDE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Infra.Mapping
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(pk => pk.ProdutoId);

            builder.Property(e => e.ProdutoAtivo)
                .IsRequired();

            builder.Property(e => e.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(e => e.ProdutoQuantidade)
                .IsRequired();

            builder.Property(e => e.ProdutoUnidadeMedida)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ProdutoGrupo)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.HasMany(e => e.ProdutoLocalizacao)
                .WithOne(e => e.Produto)
                .HasForeignKey(e => e.ProdutoId);
                

        }
    }
}
