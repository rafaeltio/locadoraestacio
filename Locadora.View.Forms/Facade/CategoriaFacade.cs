using Locadora.Core.DAO;
using Locadora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Forms.Facade
{
    class CategoriaFacade
    {
        public static IEnumerable<Categoria> ListAll()
        {
            return new CategoriaDAO().All();
        }
    }
}
