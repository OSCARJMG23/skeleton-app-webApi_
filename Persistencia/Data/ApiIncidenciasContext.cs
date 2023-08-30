using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ApiIncidenciasContext : DbContext
    {
        public ApiIncidenciasContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<TipoPersona> TiposPersonas { get; set; }
        public DbSet<TrainerSalon> TrainerSalones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<TipoGenero> TipoGeneros { get; set; }
    }
}