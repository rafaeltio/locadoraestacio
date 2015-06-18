using Locadora.Core.DAO;
using Locadora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Forms.Facade
{
    class TipoFacade
    {
        public static IEnumerable<Tipo> ListAll()
        {
            return new TipoDAO().All();
        }
    }
}
