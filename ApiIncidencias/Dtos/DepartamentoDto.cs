using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos
{
    public class DepartamentoDto
    {
        public int Id { get; set; }
        public string NombreDepartamento { get; set; }
        public List<CiudadDto> Ciudades { get; set; }
    }
}