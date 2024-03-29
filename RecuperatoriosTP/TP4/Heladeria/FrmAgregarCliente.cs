﻿using Entidades;
using System;
using System.Globalization;
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
               
                Cliente auxCliente = new Cliente(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(apellido), saldo, 0);
                try
                {
                    AccesoSql.GuardarCliente(auxCliente);
                    MessageBox.Show("Alta de cliente exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                    this.Close();
                }
                catch (ErrorSqlException ex)
                {
                    MessageBox.Show(ex.Message,
                                     "Error",
                                     MessageBoxButtons.OK);
                }
            }
        }

        private void txtSaldoCliente_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSaldoCliente.Text.Length > 0)
            {
                if (!int.TryParse(this.txtSaldoCliente.Text, out int numero))
                {
                    this.txtSaldoCliente.Text = "0";
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }
    }
}
