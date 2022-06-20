using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmMenuPrincipal : Form
    {
        public delegate void CerrarForm();

        public CerrarForm CerrarCallback { get; set; }

        public bool MostrarLogin { get; set; }
        public int VentaPorSesion { get; set; }

        public FrmMenuPrincipal(CerrarForm cerrarCallback)
        {
            CerrarCallback = cerrarCallback;
            InitializeComponent();
            //Estilos de botones
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnVolverLogin.FlatStyle = FlatStyle.Flat;
            btnVolverLogin.FlatAppearance.BorderSize = 0;
            this.toolTip1.SetToolTip(this.btnClientes, "Clientes");
            this.toolTip2.SetToolTip(this.btnVentas, "Ventas");
            this.toolTip3.SetToolTip(this.btnStock, "Productos");
            this.toolTip4.SetToolTip(this.btnVolverLogin, "Desloguearse");
            NucleoAplicacion.EmpleadoLogueado.ContarVentasEmpleado += SumarVenta;
            NucleoAplicacion.EmpleadoLogueado.ContarVentasEmpleado += ActualizarCantidadVentas;
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
            this.ChangeBody(new FrmProductos());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MostrarLogin = false;
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
                NucleoAplicacion.EmpleadoLogueado.ContarVentasEmpleado -= SumarVenta;
                NucleoAplicacion.EmpleadoLogueado.ContarVentasEmpleado -= ActualizarCantidadVentas;
                NucleoAplicacion.EmpleadoLogueado = null;
                if (MostrarLogin)
                {
                    FrmLogin.LoginForm.Show();
                }
                else 
                { 
                    if(CerrarCallback != null)
                    {
                        CerrarCallback();
                    }
                }
            }

        }
        /// <summary>
        /// Metodo que suma las ventas
        /// </summary>
        public void SumarVenta()
        {
            VentaPorSesion++;
        }
        /// <summary>
        /// Metodo que actualiza la cantidad de ventas en el label
        /// </summary>
        public void ActualizarCantidadVentas()
        {
            lblCantidadDeVentas.Text = VentaPorSesion.ToString();
        }

        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            MostrarLogin = true;
            this.Close();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.ChangeBody(new FrmVentas());
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            Cliente.CargaClientesInicial();
            Producto.CargaProductosInicial();
            lblCantidadDeVentas.Text = "0";
        }
    }
}
