using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            lblResultado.Text = " ";
            this.cmbOperador.SelectedIndex = 0;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            if (String.IsNullOrWhiteSpace(txtNumero1.Text) || String.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                MessageBox.Show("¡Debes completar con ambos numeros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Double.TryParse(txtNumero1.Text, out double numero1) || Double.IsNaN(numero1) || !Double.TryParse(txtNumero2.Text, out double numero2) || Double.IsNaN(numero2))
                {
                    MessageBox.Show("Debes ingresar numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cmbOperador.SelectedIndex == 0)
                    {
                        operador = "+";
                    }
                    else
                    {
                        operador = cmbOperador.SelectedItem.ToString();
                    }
                    lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString()).ToString();
                    lstOperaciones.Items.Add(txtNumero1.Text + operador + txtNumero2.Text + "=" + lblResultado.Text);
                }
            }
        }

        /// <summary>
        /// Realiza la operacion llamando al metodo operar 
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador</param>
        /// <returns>Retorna un double resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            resultado = Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
            if (resultado == double.MinValue)
            {
                MessageBox.Show("No se pudo dividir por cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblResultado.Text))
            {
                Operando numero = new Operando();
                double resultado;
                if (!(Double.TryParse(lblResultado.Text, out resultado)))
                {
                    MessageBox.Show("No se pueden convertir numeros negativos a binarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
                lstOperaciones.Items.Add(this.lblResultado.Text);
            }
            else
            {
                MessageBox.Show("¡No hay numero para convertir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblResultado.Text))
            {
                Operando numero = new Operando();
                this.lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
                lstOperaciones.Items.Add(this.lblResultado.Text);
            }
            else
            {
                MessageBox.Show("¡No hay numero para convertir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar la calculadora?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
