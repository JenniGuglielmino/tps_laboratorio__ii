using Entidades;
using Entidades.Enumerados;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmEditarProducto : Form
    {
        public Producto productoSeleccionado;
        string nombre;
        double precio;
        int cantidad;
        string descripcion;
        float peso;
        int unidadesPorCaja;
        ETipoProducto tipoProducto;
        public FrmEditarProducto(Producto producto)
        {
            InitializeComponent();
            productoSeleccionado = producto;
            this.txtPrecioProducto.Text = productoSeleccionado.Precio.ToString();
            this.txtCantidadProducto.Text = productoSeleccionado.Cantidad.ToString();
            this.cmbTipoProducto.SelectedValue = productoSeleccionado.TipoProducto;
            this.txtDescripcionProducto.Text = productoSeleccionado.Descripcion;
            this.txtPeso.Text = productoSeleccionado.Peso.ToString();
            this.txtNombreProducto.Text = productoSeleccionado.Nombre;
            if (productoSeleccionado is Helado)
            {
                this.txtUnidadesPorCaja.Text = (productoSeleccionado as Helado).Bochas.ToString();
            }
            else if (productoSeleccionado is Postre)
            {
                this.txtUnidadesPorCaja.Text = (productoSeleccionado as Postre).UnidadesPorCaja.ToString();
            }
            else if(productoSeleccionado is PizzaCongelada)
            {
                this.txtUnidadesPorCaja.Text = (productoSeleccionado as PizzaCongelada).CantidadDePorciones.ToString();
            }

        }

        private void FrmEditarStock_Load(object sender, EventArgs e)
        {
            Array enums = Enum.GetValues(typeof(ETipoProducto));
            foreach (var item in enums)
            {
                this.cmbTipoProducto.Items.Add(item);
            }
            this.cmbTipoProducto.SelectedItem = productoSeleccionado.TipoProducto;
            CambiarFormSegunTipo();
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
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarFormSegunTipo();
        }

        public void CambiarFormSegunTipo()
        {
            if (this.cmbTipoProducto.Text == "Postre")
            {
                this.lblUnidades.Text = "Unidades por caja";
            }
            else if (this.cmbTipoProducto.Text == "Helado")
            {
                this.lblUnidades.Text = "Bochas";
            }
            else
            {
                this.lblUnidades.Text = "Porciones";
            }
        }
    }
}
