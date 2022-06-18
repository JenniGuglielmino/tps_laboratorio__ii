using Entidades;
using System;
using System.Windows.Forms;

namespace Heladeria
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
            this.dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btnNuevaVenta.FlatStyle = FlatStyle.Flat;
            btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.toolTip1.SetToolTip(this.btnNuevaVenta, "Nueva venta");
        }

        void CargarVentas()
        {
            if (Venta.Ventas.Count > 0)
            {
                dgvVentas.DataSource = Venta.ListarVentas();
            }
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            Form form = new FrmAgregarVenta();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarVentas();
            }
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }
    }
}
