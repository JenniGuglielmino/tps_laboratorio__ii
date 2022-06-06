
namespace Heladeria
{
    partial class FrmStock
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
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnAgregarStock = new System.Windows.Forms.Button();
            this.btnEditarStock = new System.Windows.Forms.Button();
            this.btnEliminarStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(2, 3);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowTemplate.Height = 25;
            this.dgvStock.Size = new System.Drawing.Size(763, 347);
            this.dgvStock.TabIndex = 0;
            // 
            // btnAgregarStock
            // 
            this.btnAgregarStock.Location = new System.Drawing.Point(207, 356);
            this.btnAgregarStock.Name = "btnAgregarStock";
            this.btnAgregarStock.Size = new System.Drawing.Size(103, 23);
            this.btnAgregarStock.TabIndex = 1;
            this.btnAgregarStock.Text = "Agregar";
            this.btnAgregarStock.UseVisualStyleBackColor = true;
            this.btnAgregarStock.Click += new System.EventHandler(this.btnAgregarStock_Click);
            // 
            // btnEditarStock
            // 
            this.btnEditarStock.Location = new System.Drawing.Point(336, 356);
            this.btnEditarStock.Name = "btnEditarStock";
            this.btnEditarStock.Size = new System.Drawing.Size(75, 23);
            this.btnEditarStock.TabIndex = 2;
            this.btnEditarStock.Text = "Editar";
            this.btnEditarStock.UseVisualStyleBackColor = true;
            this.btnEditarStock.Click += new System.EventHandler(this.btnEditarStock_Click);
            // 
            // btnEliminarStock
            // 
            this.btnEliminarStock.Location = new System.Drawing.Point(441, 356);
            this.btnEliminarStock.Name = "btnEliminarStock";
            this.btnEliminarStock.Size = new System.Drawing.Size(88, 23);
            this.btnEliminarStock.TabIndex = 3;
            this.btnEliminarStock.Text = "Eliminar";
            this.btnEliminarStock.UseVisualStyleBackColor = true;
            this.btnEliminarStock.Click += new System.EventHandler(this.btnEliminarStock_Click);
            // 
            // FrmStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(766, 420);
            this.ControlBox = false;
            this.Controls.Add(this.btnEliminarStock);
            this.Controls.Add(this.btnEditarStock);
            this.Controls.Add(this.btnAgregarStock);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnAgregarStock;
        private System.Windows.Forms.Button btnEditarStock;
        private System.Windows.Forms.Button btnEliminarStock;
    }
}