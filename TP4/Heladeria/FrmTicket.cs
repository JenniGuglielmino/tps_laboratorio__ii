using Entidades;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Environment;

namespace Heladeria
{
    public partial class FrmTicket : Form
    {
        string ticketBody;
        public string TicketBody
        {
            get
            {
                return this.ticketBody;
            }
            set
            {
                this.ticketBody = value;
            }
        }
        public FrmTicket(string ticket)
        {
            InitializeComponent();
            this.TicketBody = ticket;
        }

        private void FrmTicket_Load(object sender, EventArgs e)
        {
            this.lblTicket.Text = this.TicketBody;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivoTexto archivo = new ArchivoTexto();
                string ruta = Environment.CurrentDirectory;
                ruta += @"\Tickets";
                string path = ruta + @"\Ticket" + DateTime.Now.ToString("HH_mm_ss") + ".txt";
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                archivo.Escribir(this.TicketBody, path);
                MessageBox.Show("Descarga exitosa",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                this.Close();
            }
            catch(ArchivoSinPermisosException ex)
            {
                MessageBox.Show(ex.Message,
                                     "Error",
                                     MessageBoxButtons.OK);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
