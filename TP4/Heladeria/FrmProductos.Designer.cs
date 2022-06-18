
namespace Heladeria
{
    partial class FrmProductos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnAgregarStock = new System.Windows.Forms.Button();
            this.btnEditarStock = new System.Windows.Forms.Button();
            this.btnEliminarStock = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(-1, -4);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStock.RowTemplate.Height = 25;
            this.dgvStock.Size = new System.Drawing.Size(792, 359);
            this.dgvStock.TabIndex = 0;
            // 
            // btnAgregarStock
            // 
            this.btnAgregarStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAgregarStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarStock.BackgroundImage")));
            this.btnAgregarStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarStock.Location = new System.Drawing.Point(362, 368);
            this.btnAgregarStock.Name = "btnAgregarStock";
            this.btnAgregarStock.Size = new System.Drawing.Size(23, 23);
            this.btnAgregarStock.TabIndex = 1;
            this.btnAgregarStock.UseVisualStyleBackColor = false;
            this.btnAgregarStock.Click += new System.EventHandler(this.btnAgregarStock_Click);
            // 
            // btnEditarStock
            // 
            this.btnEditarStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarStock.BackgroundImage")));
            this.btnEditarStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarStock.Location = new System.Drawing.Point(406, 368);
            this.btnEditarStock.Name = "btnEditarStock";
            this.btnEditarStock.Size = new System.Drawing.Size(23, 23);
            this.btnEditarStock.TabIndex = 2;
            this.btnEditarStock.UseVisualStyleBackColor = true;
            this.btnEditarStock.Click += new System.EventHandler(this.btnEditarStock_Click);
            // 
            // btnEliminarStock
            // 
            this.btnEliminarStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarStock.BackgroundImage")));
            this.btnEliminarStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarStock.Location = new System.Drawing.Point(451, 368);
            this.btnEliminarStock.Name = "btnEliminarStock";
            this.btnEliminarStock.Size = new System.Drawing.Size(23, 23);
            this.btnEliminarStock.TabIndex = 3;
            this.btnEliminarStock.UseVisualStyleBackColor = true;
            this.btnEliminarStock.Click += new System.EventHandler(this.btnEliminarStock_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportar.Location = new System.Drawing.Point(319, 368);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(23, 23);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FrmProductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(790, 420);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnEliminarStock);
            this.Controls.Add(this.btnEditarStock);
            this.Controls.Add(this.btnAgregarStock);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProductos";
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
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
    }
}