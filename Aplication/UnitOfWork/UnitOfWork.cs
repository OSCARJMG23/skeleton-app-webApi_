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
        public int Save(){
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
