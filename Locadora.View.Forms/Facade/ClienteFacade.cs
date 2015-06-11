using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Core.DAO;
using Locadora.Core.Entity;
using System.Windows.Forms;

namespace Locadora.View.Forms.Facade
{
    class ClienteFacade
    {
        public static void SaveOrUpdate(Cliente c) 
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();

                if (string.IsNullOrWhiteSpace(c.Nome))
                    throw new Exception("Campo Nom não pode ficar em branco.");
                if (!c.Nascimento.HasValue)
                    throw new Exception("Campo Data de Nascimento não pode ficar em branco.");
                if (c.Nascimento > DateTime.Now)
                    throw new Exception("Data de nascimento maior que o dia de hoje.");

                if (c.ID.Equals(0))
                {
                    dao.Save(c);
                }
                else 
                {
                    dao.Update(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Remove(Cliente c)
        {
            try
            {
                if (c.ID.Equals(0))
                    throw new Exception("Selecione um cliente usando um clique duplo no registro do mesmo na tabela.");
                
                new ClienteDAO().Delete(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static IEnumerable<Cliente> ListAll()
        {
            return new ClienteDAO().All();
        }

        public static IEnumerable<Cliente> SQL(string sql) 
        {
            return new ClienteDAO().GetSqlData<Cliente>(sql);
        }
    }
}
