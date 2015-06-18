using Locadora.Core.Entity;
using Locadora.View.Forms.Facade;
using Locadora.View.Forms.Util;
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
        protected BindingSource bs = new BindingSource();
        public FormCadastroFilme()
        {
            InitializeComponent();
            dataGridViewFilme.DataSource = bs;
            PopularDGVFilmes();
            //Categoria
            comboBoxCategoria.DataSource = CategoriaFacade.ListAll();
            comboBoxCategoria.DisplayMember = "Descricao";
            comboBoxCategoria.ValueMember = "ID";
            //Tipo
            comboBoxTipo.DataSource = TipoFacade.ListAll();
            comboBoxTipo.DisplayMember = "Descricao";
            comboBoxTipo.ValueMember = "ID";
        }

        public void PopularDGVFilmes()
        {
            bs.DataSource = FilmeUnidadeFacade.ListAll();
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
            PopularDGVFilmes();
        }

        private void Apagar()
        {
            throw new NotImplementedException();
        }

        private void LimparCampos()
        {
            FormTools.LimparControles(panel1.Controls);
            FormTools.LimparControles(panel2.Controls);
            textBoxIdFilme.Text = "0";
            textBoxIdUnidade.Text = "0";
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
            try
            {
                //Filme
                f.ID = int.Parse(textBoxIdFilme.Text);
                f.Titulo = textBoxTitulo.Text;
                f.Ano = maskedTextBoxAno.Text;
                f.Observacao = textBoxObs.Text;
                f.CategoriaID = int.Parse(comboBoxCategoria.SelectedValue.ToString());
                //Unidade
                u.ID = int.Parse(textBoxIdUnidade.Text);
                u.FilmeID = f.ID;
                u.TipoID = int.Parse(comboBoxTipo.SelectedValue.ToString());
                u.Valor = numValor.Value;
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato incorreto");
            }
        }
        private void dataGridViewFilmes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxIdFilme.Text            = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[0].Value.ToString();
            textBoxIdUnidade.Text          = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[1].Value.ToString();
            textBoxTitulo.Text             = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[2].Value.ToString();
            maskedTextBoxAno.Text          = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[3].Value.ToString();
            textBoxObs.Text                = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[4].Value.ToString();
            comboBoxCategoria.SelectedText = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[5].Value.ToString();
            comboBoxTipo.SelectedText      = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[6].Value.ToString();
            numValor.Text                  = ((DataGridView)sender).Rows[Convert.ToInt32(e.RowIndex)].Cells[7].Value.ToString();
        }
    }
}
