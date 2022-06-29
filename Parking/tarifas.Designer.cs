namespace Parking
{
    partial class tarifas
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
            this.dgrvTarifas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvTarifas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrvTarifas
            // 
            this.dgrvTarifas.AllowUserToAddRows = false;
            this.dgrvTarifas.AllowUserToDeleteRows = false;
            this.dgrvTarifas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvTarifas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrvTarifas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvTarifas.Location = new System.Drawing.Point(0, 0);
            this.dgrvTarifas.Name = "dgrvTarifas";
            this.dgrvTarifas.ReadOnly = true;
            this.dgrvTarifas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgrvTarifas.Size = new System.Drawing.Size(330, 392);
            this.dgrvTarifas.TabIndex = 0;
            this.dgrvTarifas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvTarifas_CellContentClick_1);
            // 
            // tarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 383);
            this.Controls.Add(this.dgrvTarifas);
            this.Name = "tarifas";
            this.Text = "TARIFAS";
            this.Load += new System.EventHandler(this.tarifas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvTarifas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvTarifas;
    }
}