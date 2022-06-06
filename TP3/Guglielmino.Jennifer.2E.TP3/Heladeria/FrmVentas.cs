﻿using Entidades;
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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        void CargarVentas()
        {
            if (Venta.Ventas.Count > 0)
            {
                dgvVentas.DataSource = new List<Venta>(Venta.Ventas);
            }
        }
    }
}
