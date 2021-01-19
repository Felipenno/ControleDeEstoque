using CDE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Infra.Mapping
{
    class LocalizacaoMapping : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.HasKey(pk => pk.LocalizacaoId);

            builder.Property(e => e.Andar)
                .IsRequired()
                .HasColumnType("char(3)");

            builder.Property(e => e.Corredor)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Prateleira)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Vao)
                .IsRequired()
                .HasColumnType("varchar(10)");
                
        }
    }
}
