using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.ToTable("salon");

            builder.Property(p => p.NombreSalon)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p=>p.Capacidad)
            .IsRequired()
            .HasColumnType("int");
        }
    }
}