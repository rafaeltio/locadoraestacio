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
using Locadora.Core.DAO;
using Locadora.View.Forms.Util;

namespace Locadora.View.Forms
{
    public partial class FormCadastro : Form
    {
        protected BindingSource bs = new BindingSource();
        public FormCadastro()
        {
            InitializeComponent();
            dataGridViewClientes.DataSource = bs;
            PopularDGVClientes();
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
            PopularDGVClientes();
        }
        private void Apagar()
        {
            Cliente c = new Cliente();

            PopularObjCliente(ref c);

            ClienteFacade.Remove(c);
        }
        private void SaveOrUpdate()
        {
            Cliente c = new Cliente();

            PopularObjCliente(ref c);

            ClienteFacade.SaveOrUpdate(c);
        }
        private void PopularObjCliente(ref Cliente c)
        {
            try
            {
                c.ID = int.Parse(textBoxID.Text);
                c.Nome = textBoxNome.Text;
                if (maskedTextBoxNascimento.Text.Equals("__/__/____"))
                    c.Nascimento = null;
                else
                    c.Nascimento = DateTime.Parse(maskedTextBoxNascimento.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato incorreto");
            }

        }
        private void LimparCampos() 
        {
            FormTools.LimparControles(panel1.Controls);
            textBoxID.Text = "0";
        }
        public void PopularDGVClientes()
        {
            bs.DataSource = ClienteFacade.ListAll();
        }
        private void dataGridViewClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxID.Text = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Value.ToString();
            textBoxNome.Text = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[1].Value.ToString();
            maskedTextBoxNascimento.Text = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[2].Value.ToString();
        }
    }
}
