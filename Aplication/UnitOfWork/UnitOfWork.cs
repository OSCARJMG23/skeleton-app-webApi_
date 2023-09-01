using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia.Data;


namespace Aplication.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiIncidenciasContext _context;
        private PaisRepository _paises;
        private DepartamentoRepository _departamentos;

        public UnitOfWork(ApiIncidenciasContext context)
        {
            _context = context;
        }

        public IPaisInterface Paises
        {
            get
            {
                if(_paises == null)
                {
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IDepartamentoInterface Departamentos
        {
            get
            {
                if(_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public int Save(){
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
