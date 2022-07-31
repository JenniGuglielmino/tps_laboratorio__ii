using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmAgregarVenta : Form
    {
        public FrmAgregarVenta()
        {
            InitializeComponent();
            this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmAgregarVenta_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Producto.ProductosFiltrados;
            dgvProductos.Columns[8].Visible = false;
            dgvClientes.DataSource = Cliente.Clientes;
            this.txtUnidades.Text = "0";
        }

        private void btnAgregarUnidad_Click(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                int value = int.Parse(this.txtUnidades.Text);
                value++;
                this.txtUnidades.Text = value.ToString();
            }
        }

        private void btnQuitarUnidades_Click(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                int value = int.Parse(this.txtUnidades.Text);
                if (value > 0)
                {
                    value--;
                    this.txtUnidades.Text = value.ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                if (!int.TryParse(this.txtUnidades.Text, out int numero))
                {
                    this.txtUnidades.Text = "0";
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Venta auxVenta;
            bool ventaOk;
            int.TryParse(this.txtUnidades.Text, out int unidades);
            if (unidades > 0)
            {
                try
                {
                    ventaOk = NucleoAplicacion.EmpleadoLogueado.Vender((Producto)dgvProductos.CurrentRow.DataBoundItem, (Cliente)dgvClientes.CurrentRow.DataBoundItem,
                        unidades, out auxVenta);
                    if (ventaOk)
                    {
                        AccesoSql.GuardarVenta(auxVenta);
                        MessageBox.Show("Venta guardada correctamente",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                        Form form = new FrmTicket(auxVenta.ObtenerTicket("Frido"));
                        DialogResult dialogRes = form.ShowDialog();
                        if (dialogRes != DialogResult.None)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la venta",
                                          "Error",
                                          MessageBoxButtons.OK);
                    }
                }
                catch (ClienteSinDineroException ex)
                {
                    MessageBox.Show(ex.Message,
                                      "Error",
                                      MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message,
                                      "Error",
                                      MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad de unidades superior a 0",
                                      "Error",
                                      MessageBoxButtons.OK);
            }

        }
    }
}
