using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TipoGenero : BaseEntity
    {
        public string? NobreGenero { get; set; }
        public ICollection<Persona>? Persona { get; set; }
    }
}