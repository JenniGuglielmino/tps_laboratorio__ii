using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmEditarCliente : Form
    {
        public Cliente clienteSeleccionado;
        public FrmEditarCliente(int clienteId)
        {
            InitializeComponent();
            foreach (Cliente cliente in Cliente.Clientes)
            {
                if (cliente.Id == clienteId)
                {
                    clienteSeleccionado = cliente;
                }
            }
            this.txtSaldoCliente.Text = clienteSeleccionado.Saldo.ToString();
            this.txtNombreCliente.Text = clienteSeleccionado.Nombre;
            this.txtApellidoCliente.Text = clienteSeleccionado.Apellido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre;
            string apellido;
            double saldo;
            nombre = this.txtNombreCliente.Text;
            apellido = this.txtApellidoCliente.Text;
            saldo = double.Parse(this.txtSaldoCliente.Text);
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || saldo < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                Cliente auxCliente = new Cliente(nombre, apellido, saldo, 0);
                auxCliente.Id = clienteSeleccionado.Id;
                for (int i = 0; i < Cliente.Clientes.Count; i++)
                {
                    if (Cliente.Clientes[i] == clienteSeleccionado)
                    {
                        Cliente.Clientes[i] = auxCliente;
                        AccesoSql.ModificarCliente(auxCliente);
                        MessageBox.Show("Cliente editado con exito",
                                    "Operacion exitosa",
                                    MessageBoxButtons.OK);
                        break;
                    }
                }
                this.Close();
            }
        }

        private void FrmEditarCliente_Load(object sender, EventArgs e)
        {
            double saldo = double.Parse(this.txtSaldoCliente.Text);
            this.txtNombreCliente.Text = clienteSeleccionado.Nombre;
            this.txtApellidoCliente.Text = clienteSeleccionado.Apellido;
            saldo = clienteSeleccionado.Saldo;

        }
    }
}
