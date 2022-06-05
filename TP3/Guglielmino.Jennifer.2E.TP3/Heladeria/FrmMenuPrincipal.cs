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
    }
}
