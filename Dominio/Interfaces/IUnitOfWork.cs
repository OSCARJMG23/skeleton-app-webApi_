using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisInterface Paises {get;}
        IDepartamentoInterface Departamentos {get;}

        Task<int> SaveAsync();
    }
}