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
        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Paises  as IQueryable<Pais>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NombrePais.ToLower().Contains(search));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                    .Include(u =>u.Departamentos)
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }
    }
