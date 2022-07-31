using Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace Heladeria
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            btnAgregarStock.FlatStyle = FlatStyle.Flat;
            btnAgregarStock.FlatAppearance.BorderSize = 0;
            btnEditarStock.FlatStyle = FlatStyle.Flat;
            btnEditarStock.FlatAppearance.BorderSize = 0;
            btnEliminarStock.FlatStyle = FlatStyle.Flat;
            btnEliminarStock.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderSize = 0;
            this.dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.toolTip1.SetToolTip(this.btnExportar, "Exportar");
            this.toolTip2.SetToolTip(this.btnAgregarStock, "Agregar");
            this.toolTip3.SetToolTip(this.btnEditarStock, "Editar");
            this.toolTip4.SetToolTip(this.btnEliminarStock, "Eliminar");

        }

        void CargarProductos()
        {
            Producto.CargaProductosInicial();
            if (Producto.ProductosFiltrados.Count > 0)
            {
                dgvStock.DataSource = new List<Producto>(Producto.ProductosFiltrados);
                this.dgvStock.Columns[8].Visible = false;
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
                Form form = new FrmEditarProducto((Producto)dgvStock.CurrentRow.DataBoundItem);
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
                            if (AccesoSql.EliminarProducto(prdt))
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Task serializar = new Task(() =>
                {
                    Serializador<List<Producto>> srl = new Serializador<List<Producto>>(IGuardable<List<Producto>>.ETipoArchivo.XML);
                    string ruta = CurrentDirectory;
                    ruta += @"\Archivos";
                    string path = ruta + @"\ListaDeProductos" + DateTime.Now.ToString("dd-MM-yyyy") + ".xml";
                    srl.Escribir(Producto.Productos, path);
                });
                serializar.Start();
                serializar.Wait();
                MessageBox.Show("Descarga exitosa",
                                           "Operacion exitosa",
                                           MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(),
                                                "Error",
                                                MessageBoxButtons.OK);
            }

        }

    }
}
