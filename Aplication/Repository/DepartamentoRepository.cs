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
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoInterface
    {
        private readonly ApiIncidenciasContext _context;
        public DepartamentoRepository(ApiIncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos
                .Include(p=>p.Ciudades)
                .ToListAsync();
        }
        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
            .Include(p=>p.Ciudades)
            .FirstOrDefaultAsync(p=>p.Id ==id);
        }
    }
}