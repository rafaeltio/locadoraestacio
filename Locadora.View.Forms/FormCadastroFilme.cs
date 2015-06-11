using Locadora.Core.Entity;
using Locadora.View.Forms.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.View.Forms
{
    public partial class FormCadastroFilme : Form
    {
        public FormCadastroFilme()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            switch (((Control)sender).Text)
            {
                case "Gravar":
                    SaveOrUpdate();
                    break;
                case "Apagar":
                    Apagar();
                    break;
            }
            LimparCampos();
            //PopularDGVClientes();
        }

        private void Apagar()
        {
            throw new NotImplementedException();
        }

        private void LimparCampos()
        {
            throw new NotImplementedException();
        }

        private void SaveOrUpdate()
        {
            Unidade u = new Unidade();
            Filme f = new Filme();

            PopularObjs(ref u, ref f);

            FilmeUnidadeFacade.SaveOrUpdate(u, f);
        }

        private void PopularObjs(ref Unidade u, ref Filme f)
        {
            throw new NotImplementedException();
        }
    }
}
