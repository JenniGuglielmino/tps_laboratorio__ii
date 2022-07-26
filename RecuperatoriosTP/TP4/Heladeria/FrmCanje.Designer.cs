
namespace Heladeria
{
    partial class FrmCanje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCanje));
            this.cmbPremios = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPuntosRequeridos = new System.Windows.Forms.Label();
            this.lblPuntosDelProducto = new System.Windows.Forms.Label();
            this.lblPuntosTotales = new System.Windows.Forms.Label();
            this.lblPuntosCliente = new System.Windows.Forms.Label();
            this.cmbNombreProducto = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbPremios
            // 
            this.cmbPremios.FormattingEnabled = true;
            this.cmbPremios.Location = new System.Drawing.Point(48, 39);
            this.cmbPremios.Name = "cmbPremios";
            this.cmbPremios.Size = new System.Drawing.Size(121, 23);
            this.cmbPremios.TabIndex = 0;
            this.cmbPremios.SelectedIndexChanged += new System.EventHandler(this.cmbPremios_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(114)))), ((int)(((byte)(178)))));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(12, 415);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(114)))), ((int)(((byte)(178)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(130, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPuntosRequeridos
            // 
            this.lblPuntosRequeridos.AutoSize = true;
            this.lblPuntosRequeridos.Location = new System.Drawing.Point(48, 151);
            this.lblPuntosRequeridos.Name = "lblPuntosRequeridos";
            this.lblPuntosRequeridos.Size = new System.Drawing.Size(106, 15);
            this.lblPuntosRequeridos.TabIndex = 3;
            this.lblPuntosRequeridos.Text = "Puntos requeridos:";
            // 
            // lblPuntosDelProducto
            // 
            this.lblPuntosDelProducto.AutoSize = true;
            this.lblPuntosDelProducto.Location = new System.Drawing.Point(48, 170);
            this.lblPuntosDelProducto.Name = "lblPuntosDelProducto";
            this.lblPuntosDelProducto.Size = new System.Drawing.Size(0, 15);
            this.lblPuntosDelProducto.TabIndex = 4;
            // 
            // lblPuntosTotales
            // 
            this.lblPuntosTotales.AutoSize = true;
            this.lblPuntosTotales.Location = new System.Drawing.Point(48, 229);
            this.lblPuntosTotales.Name = "lblPuntosTotales";
            this.lblPuntosTotales.Size = new System.Drawing.Size(88, 15);
            this.lblPuntosTotales.TabIndex = 5;
            this.lblPuntosTotales.Text = "Puntos totales: ";
            // 
            // lblPuntosCliente
            // 
            this.lblPuntosCliente.AutoSize = true;
            this.lblPuntosCliente.Location = new System.Drawing.Point(48, 257);
            this.lblPuntosCliente.Name = "lblPuntosCliente";
            this.lblPuntosCliente.Size = new System.Drawing.Size(0, 15);
            this.lblPuntosCliente.TabIndex = 6;
            // 
            // cmbNombreProducto
            // 
            this.cmbNombreProducto.FormattingEnabled = true;
            this.cmbNombreProducto.Location = new System.Drawing.Point(48, 90);
            this.cmbNombreProducto.Name = "cmbNombreProducto";
            this.cmbNombreProducto.Size = new System.Drawing.Size(121, 23);
            this.cmbNombreProducto.TabIndex = 7;
            // 
            // FrmCanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(223, 450);
            this.Controls.Add(this.cmbNombreProducto);
            this.Controls.Add(this.lblPuntosCliente);
            this.Controls.Add(this.lblPuntosTotales);
            this.Controls.Add(this.lblPuntosDelProducto);
            this.Controls.Add(this.lblPuntosRequeridos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbPremios);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCanje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPremios;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPuntosRequeridos;
        private System.Windows.Forms.Label lblPuntosDelProducto;
        private System.Windows.Forms.Label lblPuntosTotales;
        private System.Windows.Forms.Label lblPuntosCliente;
        private System.Windows.Forms.ComboBox cmbNombreProducto;
    }
}