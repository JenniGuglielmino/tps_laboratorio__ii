using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmCanje : Form
    {
        public Cliente clienteSeleccionado;
        public FrmCanje(int clienteId)
        {
            InitializeComponent();
            foreach (Cliente cliente in Cliente.Clientes)
            {
                if (cliente.Id == clienteId)
                {
                    clienteSeleccionado = cliente;
                }
            }
        }

        private void FrmCanje_Load(object sender, EventArgs e)
        {
            foreach (Producto item in Producto.Productos)
            {
                if (item is ICanjeable)
                {
                    if (!this.cmbPremios.Items.Contains(item.TipoProducto) && (item as IStockeable).HayStock(1))
                    {
                        this.cmbPremios.Items.Add(item.TipoProducto);
                    }
                }
            }
            this.lblPuntosCliente.Text = this.clienteSeleccionado.Puntos.ToString();
            this.lblPuntosDelProducto.Text = "0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPremios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbNombreProducto.Items.Clear();
            this.cmbNombreProducto.Text = "";
            foreach (Producto prod in Producto.Productos)
            {
                if (prod.TipoProducto.ToString() == this.cmbPremios.Text)
                {
                    this.lblPuntosDelProducto.Text = (prod as ICanjeable).CostoEnPuntos.ToString();
                    this.cmbNombreProducto.Items.Add(prod.Nombre);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool canjeOk = false;
            Producto productoSeleccionado = null;
            foreach (Producto prod in Producto.Productos)
            {
                if (prod.TipoProducto.ToString() == this.cmbPremios.Text && prod.Nombre == this.cmbNombreProducto.Text)
                {
                    productoSeleccionado = prod;
                }
            }
            try
            {
                if (productoSeleccionado is not null)
                {
                    canjeOk = clienteSeleccionado.Canjear(productoSeleccionado);
                }
               
                if (canjeOk)
                {
                    MessageBox.Show("Canje exitoso",
                                    "Operacion exitosa",
                                    MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al realizar el canje",
                                      "Error",
                                      MessageBoxButtons.OK);
                }
            }
            catch (ClienteSinPuntosException ex)
            {
                MessageBox.Show(ex.MensajeError,
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
    }
}
