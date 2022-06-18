
namespace Heladeria
{
    partial class FrmAgregarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarVenta));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.btnAgregarUnidad = new System.Windows.Forms.Button();
            this.btnQuitarUnidades = new System.Windows.Forms.Button();
            this.lblUnidades = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.btnAceptar.Location = new System.Drawing.Point(321, 415);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Location = new System.Drawing.Point(412, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 39);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowTemplate.Height = 25;
            this.dgvProductos.Size = new System.Drawing.Size(783, 150);
            this.dgvProductos.TabIndex = 3;
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(13, 221);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.Size = new System.Drawing.Size(783, 170);
            this.dgvClientes.TabIndex = 4;
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new System.Drawing.Point(13, 203);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(49, 15);
            this.lblClientes.TabIndex = 5;
            this.lblClientes.Text = "Clientes";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Location = new System.Drawing.Point(12, 18);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(61, 15);
            this.lblProductos.TabIndex = 6;
            this.lblProductos.Text = "Productos";
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(56, 416);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(100, 23);
            this.txtUnidades.TabIndex = 7;
            this.txtUnidades.TextChanged += new System.EventHandler(this.txtUnidades_TextChanged);
            // 
            // btnAgregarUnidad
            // 
            this.btnAgregarUnidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.btnAgregarUnidad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarUnidad.BackgroundImage")));
            this.btnAgregarUnidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarUnidad.Location = new System.Drawing.Point(162, 416);
            this.btnAgregarUnidad.Name = "btnAgregarUnidad";
            this.btnAgregarUnidad.Size = new System.Drawing.Size(23, 23);
            this.btnAgregarUnidad.TabIndex = 8;
            this.btnAgregarUnidad.UseVisualStyleBackColor = false;
            this.btnAgregarUnidad.Click += new System.EventHandler(this.btnAgregarUnidad_Click);
            // 
            // btnQuitarUnidades
            // 
            this.btnQuitarUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.btnQuitarUnidades.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarUnidades.BackgroundImage")));
            this.btnQuitarUnidades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitarUnidades.Location = new System.Drawing.Point(23, 415);
            this.btnQuitarUnidades.Name = "btnQuitarUnidades";
            this.btnQuitarUnidades.Size = new System.Drawing.Size(23, 23);
            this.btnQuitarUnidades.TabIndex = 9;
            this.btnQuitarUnidades.UseVisualStyleBackColor = false;
            this.btnQuitarUnidades.Click += new System.EventHandler(this.btnQuitarUnidades_Click);
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Location = new System.Drawing.Point(79, 398);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(56, 15);
            this.lblUnidades.TabIndex = 10;
            this.lblUnidades.Text = "Unidades";
            // 
            // FrmAgregarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(200)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.lblUnidades);
            this.Controls.Add(this.btnQuitarUnidades);
            this.Controls.Add(this.btnAgregarUnidad);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarVenta";
            this.Load += new System.EventHandler(this.FrmAgregarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Button btnAgregarUnidad;
        private System.Windows.Forms.Button btnQuitarUnidades;
        private System.Windows.Forms.Label lblUnidades;
    }
}