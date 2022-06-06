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
    public partial class FrmEditarStock : Form
    {
        public Producto productoSeleccionado;
        string nombre;
        double precio;
        int cantidad;
        string descripcion;
        float peso;
        int unidadesPorCaja;
        ETipoProducto tipoProducto;
        public FrmEditarStock(Producto producto)
        {
            InitializeComponent();
            productoSeleccionado = producto;
            this.txtPrecioProducto.Text = productoSeleccionado.Precio.ToString();
            this.txtCantidadProducto.Text = productoSeleccionado.Cantidad.ToString();
            this.cmbTipoProducto.SelectedItem = productoSeleccionado.TipoProducto;
            this.txtDescripcionProducto.Text = productoSeleccionado.Descripcion;
            this.txtPeso.Text = productoSeleccionado.Peso.ToString();
            this.txtNombreProducto.Text = productoSeleccionado.Nombre;

        }

        private void FrmEditarStock_Load(object sender, EventArgs e)
        {
            double precio = double.Parse(this.txtPrecioProducto.Text);
            int cantidad = int.Parse(this.txtPrecioProducto.Text);
            int unidadesPorCaja = int.Parse(this.txtUnidadesPorCaja.Text);
            float peso = float.Parse(this.txtPrecioProducto.Text);

            precio = productoSeleccionado.Precio;
            cantidad = productoSeleccionado.Cantidad;
            this.cmbTipoProducto.SelectedItem = productoSeleccionado.TipoProducto;
            this.txtDescripcionProducto.Text = productoSeleccionado.Descripcion;
            peso = productoSeleccionado.Peso;
            this.txtNombreProducto.Text = productoSeleccionado.Nombre;

            Array enums = Enum.GetValues(typeof(ETipoProducto));
            foreach (var item in enums)
            {
                this.cmbTipoProducto.Items.Add(item);
            }
            this.cmbTipoProducto.SelectedItem = this.cmbTipoProducto.Items[0];
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cantidad = int.Parse(this.txtCantidadProducto.Text);
            tipoProducto = (ETipoProducto)this.cmbTipoProducto.SelectedItem;
            precio = double.Parse(this.txtPrecioProducto.Text);
            descripcion = this.txtDescripcionProducto.Text;
            peso = float.Parse(this.txtPrecioProducto.Text);
            nombre = this.txtNombreProducto.Text;
            unidadesPorCaja = int.Parse(this.txtUnidadesPorCaja.Text);

            if (precio < 1 || cantidad < 1)
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
                    auxProducto.Id = productoSeleccionado.Id;
                    for (int i = 0; i < Producto.Productos.Count; i++)
                    {
                        if (Producto.Productos[i] == productoSeleccionado)
                        {
                            Producto.Productos[i] = auxProducto;
                            MessageBox.Show("Producto editado con exito",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
                else if (tipoProducto.ToString() == "Helado")
                {
                    Helado auxProducto = new Helado(nombre, descripcion, cantidad, precio, peso, tipoProducto, unidadesPorCaja);
                    auxProducto.Id = productoSeleccionado.Id;
                    for (int i = 0; i < Producto.Productos.Count; i++)
                    {
                        if (Producto.Productos[i] == productoSeleccionado)
                        {
                            Producto.Productos[i] = auxProducto;
                            MessageBox.Show("Producto editado con exito",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
                else 
                {
                    PizzaCongelada auxProducto = new PizzaCongelada(nombre, descripcion, cantidad, precio, peso, tipoProducto, unidadesPorCaja);
                    auxProducto.Id = productoSeleccionado.Id;
                    for (int i = 0; i < Producto.Productos.Count; i++)
                    {
                        if (Producto.Productos[i] == productoSeleccionado)
                        {
                            Producto.Productos[i] = auxProducto;
                            MessageBox.Show("Producto editado con exito",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
