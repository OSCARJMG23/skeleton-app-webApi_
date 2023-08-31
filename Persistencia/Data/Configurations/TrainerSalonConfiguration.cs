using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
    {
        public void Configure(EntityTypeBuilder<TrainerSalon> builder)
        {
            builder.ToTable("trainerSalon");


            builder
            .HasOne(p=>p.Persona)
            .WithMany(p =>p.TrainerSalones)
            .HasForeignKey(p =>p.IdPersonaFk);

            builder
            .HasOne(p=>p.Salon)
            .WithMany(p =>p.TrainerSalones)
            .HasForeignKey(p =>p.IdSalonFk);
        }
    }
}