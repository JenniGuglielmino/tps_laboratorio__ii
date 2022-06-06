using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form form = new FrmAgregarCliente();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarClientes();
            }
        }
        void CargarClientes()
        {
            if (Cliente.Clientes.Count > 0)
            {
                dgvListaClientes.DataSource = new List<Cliente>(Cliente.Clientes);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaClientes.SelectedCells.Count > 0)
            {
                int indexSeleccionado = this.dgvListaClientes.SelectedCells[0].RowIndex;
                int idClienteSeleccionado = (int)dgvListaClientes.Rows[indexSeleccionado].Cells["Id"].Value;
                Form form = new FrmEditarCliente(idClienteSeleccionado);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarClientes();
                }
            }
        }
    }
}
