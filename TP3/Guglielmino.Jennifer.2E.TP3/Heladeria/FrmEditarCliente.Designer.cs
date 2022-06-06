
namespace Heladeria
{
    partial class FrmEditarCliente
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtSaldoCliente = new System.Windows.Forms.TextBox();
            this.txtPuntosClientes = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblSaldoCliente = new System.Windows.Forms.Label();
            this.lblPuntosCliente = new System.Windows.Forms.Label();
            this.lblApellidoCliente = new System.Windows.Forms.Label();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(21, 405);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(41, 53);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(176, 23);
            this.txtNombreCliente.TabIndex = 2;
            // 
            // txtSaldoCliente
            // 
            this.txtSaldoCliente.Location = new System.Drawing.Point(41, 170);
            this.txtSaldoCliente.Name = "txtSaldoCliente";
            this.txtSaldoCliente.Size = new System.Drawing.Size(176, 23);
            this.txtSaldoCliente.TabIndex = 3;
            // 
            // txtPuntosClientes
            // 
            this.txtPuntosClientes.Location = new System.Drawing.Point(41, 244);
            this.txtPuntosClientes.Name = "txtPuntosClientes";
            this.txtPuntosClientes.Size = new System.Drawing.Size(176, 23);
            this.txtPuntosClientes.TabIndex = 4;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(41, 32);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(51, 15);
            this.lblNombreCliente.TabIndex = 5;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // lblSaldoCliente
            // 
            this.lblSaldoCliente.AutoSize = true;
            this.lblSaldoCliente.Location = new System.Drawing.Point(41, 149);
            this.lblSaldoCliente.Name = "lblSaldoCliente";
            this.lblSaldoCliente.Size = new System.Drawing.Size(36, 15);
            this.lblSaldoCliente.TabIndex = 6;
            this.lblSaldoCliente.Text = "Saldo";
            // 
            // lblPuntosCliente
            // 
            this.lblPuntosCliente.AutoSize = true;
            this.lblPuntosCliente.Location = new System.Drawing.Point(41, 223);
            this.lblPuntosCliente.Name = "lblPuntosCliente";
            this.lblPuntosCliente.Size = new System.Drawing.Size(44, 15);
            this.lblPuntosCliente.TabIndex = 7;
            this.lblPuntosCliente.Text = "Puntos";
            // 
            // lblApellidoCliente
            // 
            this.lblApellidoCliente.AutoSize = true;
            this.lblApellidoCliente.Location = new System.Drawing.Point(41, 89);
            this.lblApellidoCliente.Name = "lblApellidoCliente";
            this.lblApellidoCliente.Size = new System.Drawing.Size(51, 15);
            this.lblApellidoCliente.TabIndex = 8;
            this.lblApellidoCliente.Text = "Apellido";
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(41, 108);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(176, 23);
            this.txtApellidoCliente.TabIndex = 9;
            // 
            // FrmEditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(264, 458);
            this.Controls.Add(this.txtApellidoCliente);
            this.Controls.Add(this.lblApellidoCliente);
            this.Controls.Add(this.lblPuntosCliente);
            this.Controls.Add(this.lblSaldoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.txtPuntosClientes);
            this.Controls.Add(this.txtSaldoCliente);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditarCliente";
            this.Load += new System.EventHandler(this.FrmEditarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtSaldoCliente;
        private System.Windows.Forms.TextBox txtPuntosClientes;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblSaldoCliente;
        private System.Windows.Forms.Label lblPuntosCliente;
        private System.Windows.Forms.Label lblApellidoCliente;
        private System.Windows.Forms.TextBox txtApellidoCliente;
    }
}