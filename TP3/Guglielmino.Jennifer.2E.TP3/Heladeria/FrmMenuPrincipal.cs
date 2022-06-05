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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Metodo estatico que pasandole un controlcollection y un form, le da formato para mostrarse dentro del control sin barra superior y ocupando todo el espacio disponible
        /// </summary>
        /// <param name="controlCollection">Control al que se le va a realizar el Add() del formulario</param>
        /// <param name="sourceForm">instancia del formulario a agregar</param>
        /// <returns>devuelve la instancia del formulario con los formatos aplicados</returns>
        public static Form AddFormToControl(Control.ControlCollection controlCollection, Form sourceForm)
        {
            controlCollection.Remove(sourceForm);
            sourceForm.Dock = DockStyle.Fill;
            sourceForm.TopLevel = false;
            sourceForm.TopMost = true;
            sourceForm.FormBorderStyle = FormBorderStyle.None;
            controlCollection.Add(sourceForm);
            sourceForm.Show();
            return sourceForm;
        }

        /// <summary>
        /// Metodo que se ocupa de cambiar contenido del paner principal del form Inicio con una instancia de un form dada, limpia el control y luego agrega la nueva vista
        /// </summary>
        /// <param name="formToUse">Instancia del form a mostrar</param>
        public void ChangeBody(Form formToUse)
        {
            pContenido.Controls.Clear();
            formToUse.Dock = DockStyle.Fill;
            formToUse.TopLevel = false;
            formToUse.TopMost = true;
            formToUse.FormBorderStyle = FormBorderStyle.None;
            pContenido.Controls.Add(formToUse);
            formToUse.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.ChangeBody(new FrmClientes());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.ChangeBody(new FrmStock());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?",
                        "Confirmacion",
                        MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else 
            {
                FrmLogin.LoginForm.Close();
            }
        }

        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea cerrar su sesion?",
                                   "Confirmacion",
                                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                FrmLogin.LoginForm.Show();
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.pContenido = new System.Windows.Forms.Panel();
            this.btnVolverLogin = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pContenido
            // 
            this.pContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContenido.Location = new System.Drawing.Point(12, 62);
            this.pContenido.Name = "pContenido";
            this.pContenido.Size = new System.Drawing.Size(786, 409);
            this.pContenido.TabIndex = 0;
            // 
            // btnVolverLogin
            // 
            this.btnVolverLogin.Location = new System.Drawing.Point(12, 13);
            this.btnVolverLogin.Name = "btnVolverLogin";
            this.btnVolverLogin.Size = new System.Drawing.Size(129, 43);
            this.btnVolverLogin.TabIndex = 1;
            this.btnVolverLogin.Text = "Volver";
            this.btnVolverLogin.UseVisualStyleBackColor = true;
            this.btnVolverLogin.Click += new System.EventHandler(this.btnVolverLogin_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(669, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 43);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClientes.Location = new System.Drawing.Point(12, 477);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(129, 43);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVentas.Location = new System.Drawing.Point(344, 477);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(129, 43);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnStock
            // 
            this.btnStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStock.Location = new System.Drawing.Point(669, 477);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(129, 43);
            this.btnStock.TabIndex = 5;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(810, 525);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVolverLogin);
            this.Controls.Add(this.pContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.ResumeLayout(false);

        }
    }
}
