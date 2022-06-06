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
    public partial class FrmStock : Form
    {
        public FrmStock()
        {
            InitializeComponent();
        }

        void CargarProductos()
        {
            if (Producto.Productos.Count > 0)
            {
                dgvStock.DataSource = new List<Producto>(Producto.Productos);
            }
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            Form form = new FrmAgregarProducto();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarProductos();
            }
        }

        private void btnEditarStock_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedCells.Count > 0)
            {
                Form form = new FrmEditarStock((Producto)dgvStock.CurrentRow.DataBoundItem);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarProductos();
                }
            }
        }

        private void btnEliminarStock_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedCells.Count > 0)
            {
                int indexSeleccionado = this.dgvStock.SelectedCells[0].RowIndex;
                int idSeleccionado = (int)dgvStock.Rows[indexSeleccionado].Cells["Id"].Value;
                if (MessageBox.Show($"Seguro que desea eliminar el producto de id: {idSeleccionado}?",
                                         "Confirmacion",
                                         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    foreach (Producto prdt in Producto.Productos)
                    {
                        if (prdt.Id == idSeleccionado)
                        {
                            if (Producto.Productos - prdt)
                            {
                                MessageBox.Show("Producto eliminado",
                                         "Operacion exitosa",
                                         MessageBoxButtons.OK);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Producto no eliminado",
                                           "Error",
                                           MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                    CargarProductos();
                }
            }
        }

    }
}
