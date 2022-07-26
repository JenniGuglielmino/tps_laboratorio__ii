using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmAgregarCliente : Form
    {
        string nombre;
        string apellido;
        double saldo;
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNombreCliente.Text) || string.IsNullOrEmpty(this.txtApellidoCliente.Text)
                || string.IsNullOrEmpty(this.txtSaldoCliente.Text))
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                nombre = this.txtNombreCliente.Text;
                apellido = this.txtApellidoCliente.Text;
                saldo = double.Parse(this.txtSaldoCliente.Text);
                Cliente auxCliente = new Cliente(nombre, apellido, saldo, 0);
                bool altaOk = AccesoSql.GuardarCliente(auxCliente);
                if (altaOk)
                {
                    MessageBox.Show("Alta de cliente exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error en la carga del cliente",
                                              "Error",
                                              MessageBoxButtons.OK);
                }
                this.Close();
            }
        }

    }
}
