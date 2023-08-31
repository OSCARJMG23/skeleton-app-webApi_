using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TipoGeneroConfiguration : IEntityTypeConfiguration<TipoGenero>
    {
        public void Configure(EntityTypeBuilder<TipoGenero> builder)
        {
            builder.ToTable("tipoGenero");

            builder.Property(p => p.NobreGenero)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}