using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository;

    public class PaisRepository : GenericRepository<Pais>, IPaisInterface
    {
        private readonly ApiIncidenciasContext _context;
        public PaisRepository(ApiIncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                .Include(p=> p.Departamentos)
                .ToListAsync();
        }
        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p=> p.Departamentos).ThenInclude(c =>c.Ciudades)
            .FirstOrDefaultAsync(p=>p.Id ==id);
        }
    }
