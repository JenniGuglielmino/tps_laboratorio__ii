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
    public partial class FrmAgregarCliente : Form
    {
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
                Cliente auxCliente = new Cliente(nombre, apellido, saldo);
                bool altaOk = Cliente.Clientes + auxCliente;
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
