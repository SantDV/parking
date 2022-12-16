namespace Parking
{
    partial class facturacion
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
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dgvFacturacion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnResumen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaDesde
            // 
            this.fechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDesde.Location = new System.Drawing.Point(57, 45);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(102, 20);
            this.fechaDesde.TabIndex = 0;
            // 
            // fechaHasta
            // 
            this.fechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaHasta.Location = new System.Drawing.Point(216, 45);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(102, 20);
            this.fechaHasta.TabIndex = 1;
            // 
            // dgvFacturacion
            // 
            this.dgvFacturacion.AllowUserToAddRows = false;
            this.dgvFacturacion.AllowUserToDeleteRows = false;
            this.dgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFacturacion.Location = new System.Drawing.Point(9, 110);
            this.dgvFacturacion.Name = "dgvFacturacion";
            this.dgvFacturacion.Size = new System.Drawing.Size(426, 382);
            this.dgvFacturacion.TabIndex = 2;
            this.dgvFacturacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturacion_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(360, 45);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 5;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.Location = new System.Drawing.Point(360, 81);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(75, 23);
            this.btnResumen.TabIndex = 6;
            this.btnResumen.Text = "Resumen";
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 498);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFacturacion);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.fechaDesde);
            this.Name = "facturacion";
            this.Text = "facturacion";
            this.Load += new System.EventHandler(this.facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DataGridView dgvFacturacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnResumen;
    }
}