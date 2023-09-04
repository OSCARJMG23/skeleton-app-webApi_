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

    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadInterface
    {
        private readonly ApiIncidenciasContext _context;
        public CiudadRepository(ApiIncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades
                .Include(p => p.Personas)
                .ToListAsync();
        }
        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudades
                .Include(p=>p.Personas)
                .FirstOrDefaultAsync(p=>p.Id ==id);
        }
    }