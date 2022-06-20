using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmLogin : Form
    {
        public static Form LoginForm { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            //Acceso de usuario 
            Empleado empleado = new Empleado("juan", "1234");
            txtUsuario.Text = "juan";
            txtContrasenia.Text = "1234";

            Empleado.Empleados = new List<Empleado>();
            Empleado.Empleados.Add(empleado);
            LoginForm = this;

            //Estilo de botones
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe completar el usuario",
                                        "Error",
                                        MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                MessageBox.Show("Debe completar la contraseña",
                                       "Error",
                                       MessageBoxButtons.OK);
            }
            if (Empleado.Login(txtUsuario.Text, txtContrasenia.Text))
            {
                FrmMenuPrincipal menuPrincipal = new FrmMenuPrincipal(AlCerrarCallback);
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario o contraseña invalido");
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlCerrarCallback()
        {
            this.Close();
        }
    }
}
