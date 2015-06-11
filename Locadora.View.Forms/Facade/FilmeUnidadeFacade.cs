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
    class FilmeUnidadeFacade
    {
        public static void SaveOrUpdate(Unidade u, Filme f)
        {
            try
            {
                FilmeDAO filmeDao = new FilmeDAO();
                UnidadeDAO unidadeDao = new UnidadeDAO();

                u.FilmeID = f.ID;

                if (u.ID.Equals(0) && f.ID.Equals(0))
                {
                    filmeDao.Save(f);
                    unidadeDao.Save(u);
                }
                else
                {
                    filmeDao.Update(f);
                    unidadeDao.Update(u);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Remove(Unidade u, Filme f)
        {
            try
            {
                if (u.ID.Equals(0) && f.ID.Equals(0))
                    throw new Exception("Selecione um filme usando um clique duplo no registro do mesmo na tabela.");

                new UnidadeDAO().Delete(u);
                new FilmeDAO().Delete(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static IEnumerable<Unidade> ListAll()
        {
            return new UnidadeDAO().All();
        }

        public static IEnumerable<Unidade> SQL(string sql)
        {
            return new UnidadeDAO().GetSqlData<Unidade>(sql);
        }
    }
}
