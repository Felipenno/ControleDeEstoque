using CDE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Infra.Mapping
{
    class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(pk => pk.UsuarioId);

            builder.Property(e => e.UsuarioNome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.UsuarioCpf)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(e => e.UsuarioEmail)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.UsuarioSenha)
                .IsRequired()
                .HasColumnType("varchar(100)");

        }
    }
}
