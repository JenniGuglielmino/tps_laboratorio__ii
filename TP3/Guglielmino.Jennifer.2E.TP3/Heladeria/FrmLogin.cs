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
    public partial class FrmLogin : Form
    {
        public static Form LoginForm { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            Empleado empleado = new Empleado("juan", "1234");
            txtUsuario.Text = "juan";
            txtContrasenia.Text = "1234";
            Empleado.Empleados = new List<Empleado>();
            Empleado.Empleados.Add(empleado);
            LoginForm = this;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                //alert
                return;
            }
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                //alert
                //exepcion
                return;
            }
            if (Empleado.Login(txtUsuario.Text, txtContrasenia.Text))
            {
                FrmMenuPrincipal menuPrincipal = new FrmMenuPrincipal();
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario o contraseña invalido");
            }
            
        }
    }
}
