using Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace Heladeria
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnCanjear.FlatStyle = FlatStyle.Flat;
            btnCanjear.FlatAppearance.BorderSize = 0;
            this.dgvListaClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.toolTip1.SetToolTip(this.btnExportar, "Exportar");
            this.toolTip2.SetToolTip(this.btnEditar, "Editar");
            this.toolTip3.SetToolTip(this.btnAgregar, "Agregar");
            this.toolTip4.SetToolTip(this.btnCanjear, "Canjear");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                dgvListaClientes.BeginInvoke((MethodInvoker)delegate ()
                {
                    dgvListaClientes.Visible = true;
                    Form form = new FrmAgregarCliente();
                    DialogResult dialogRes = form.ShowDialog();
                    if (dialogRes != DialogResult.None)
                    {
                        CargarClientes();
                    }
                });

            });
        }
        void CargarClientes()
        {
            try
            {
                Cliente.CargaClientesInicial();
                if (Cliente.Clientes.Count > 0)
                {
                    dgvListaClientes.DataSource = new List<Cliente>(Cliente.Clientes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "Error",
                                 MessageBoxButtons.OK);
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                Task serializar = new Task(() =>
                {
                    Serializador<List<Cliente>> srl = new Serializador<List<Cliente>>(IGuardable<List<Cliente>>.ETipoArchivo.JSON);
                    string ruta = CurrentDirectory;
                    ruta += @"\Archivos";
                    string path = ruta + @"\ListaDeClientes" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";
                    srl.Escribir(Cliente.Clientes, path);
                });
                serializar.Start();
                serializar.Wait();
                MessageBox.Show("Descarga exitosa",
                                           "Operacion exitosa",
                                           MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                                "Error",
                                                MessageBoxButtons.OK);
            }
        }

        private void btnCanjear_Click(object sender, EventArgs e)
        {
            if (dgvListaClientes.SelectedCells.Count > 0)
            {
                int indexSeleccionado = this.dgvListaClientes.SelectedCells[0].RowIndex;
                int idClienteSeleccionado = (int)dgvListaClientes.Rows[indexSeleccionado].Cells["Id"].Value;
                Form form = new FrmCanje(idClienteSeleccionado);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarClientes();
                }
            }
        }
    }
}
