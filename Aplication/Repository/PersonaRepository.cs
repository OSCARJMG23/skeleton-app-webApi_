using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository
{
    public class PersonaRepository : GenericRepository<Persona>,IPersonaInterface
    {
        private readonly ApiIncidenciasContext _context;

        public PersonaRepository(ApiIncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .Include(p => p.Matriculas)
                .ToListAsync();
        }
        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
                .Include(p => p.Matriculas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}