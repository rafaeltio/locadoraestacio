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
                    u.FilmeID = filmeDao.Save(f).ID;
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

        public static IEnumerable<Object> ListAll()
        {
            IEnumerable<Filme> filmes = new FilmeDAO().All();
            IEnumerable<Unidade> unidades = new UnidadeDAO().All();
            IEnumerable<Categoria> categorias = new CategoriaDAO().All();
            IEnumerable<Tipo> tipos = new TipoDAO().All();

            var query = from u in unidades
                         join f in filmes
                            on u.FilmeID equals f.ID
                         join c in categorias
                            on f.CategoriaID equals c.ID
                         join t in tipos
                            on u.TipoID equals t.ID
                         select new { IDFilme = f.ID, IDUnidade = u.ID, Titulo = f.Titulo, Ano = f.Ano, Obs = f.Observacao, Categoria = c.Descricao, Tipo = t.Descricao, Valor = u.Valor };

            return query.AsEnumerable<Object>();
        }
    }
}
