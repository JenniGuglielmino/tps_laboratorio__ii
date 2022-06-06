using Entidades;
using Entidades.Enumerados;
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
    public partial class FrmAgregarProducto : Form
    {
        public Producto productoSeleccionado;
        string nombre;
        double precio;
        int cantidad;
        string descripcion;
        float peso;
        int unidadesPorCaja;
        ETipoProducto tipoProducto;
        public FrmAgregarProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cantidad = int.Parse(this.txtCantidad.Text);
            tipoProducto = (ETipoProducto)this.cmbTipoProducto.SelectedItem;
            precio = double.Parse(this.txtPrecio.Text);
            descripcion = this.txtDescripcion.Text;
            peso = float.Parse(this.txtPrecio.Text);
            nombre = this.txtNombre.Text;
            unidadesPorCaja = int.Parse(this.txtUnidades.Text);
            bool altaOk = false;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || peso < 1 || cantidad < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                if (tipoProducto.ToString() == "Postre")
                {
                    Postre auxProducto = new Postre(nombre, descripcion, cantidad, precio, peso, tipoProducto, unidadesPorCaja);
                    altaOk = Producto.Productos + auxProducto;
                }
                else if(tipoProducto.ToString() == "Helado")
                {
                    Helado auxProducto = new Helado(nombre,descripcion,cantidad,precio, peso, tipoProducto, unidadesPorCaja);
                    altaOk = Producto.Productos + auxProducto;
                }
                else
                {
                    PizzaCongelada auxProducto = new PizzaCongelada(nombre, descripcion, cantidad, precio, peso, tipoProducto, unidadesPorCaja);
                    altaOk = Producto.Productos + auxProducto;
                }
                if (altaOk)
                {
                    MessageBox.Show($"Alta de producto exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al crear el producto",
                                              "Error",
                                              MessageBoxButtons.OK);
                }
            }
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            Array enums = Enum.GetValues(typeof(ETipoProducto));
            foreach (var item in enums)
            {
                this.cmbTipoProducto.Items.Add(item);
            }
            this.cmbTipoProducto.SelectedItem = this.cmbTipoProducto.Items[0];
        }
    }
}
