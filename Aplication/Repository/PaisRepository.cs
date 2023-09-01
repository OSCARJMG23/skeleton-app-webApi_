using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplication.Repository;

    public class PaisRepository : GenericRepository<Pais>, IPaisInterface
    {
        public PaisRepository(ApiIncidenciasContext context) : base(context)
        {

        }
    }
