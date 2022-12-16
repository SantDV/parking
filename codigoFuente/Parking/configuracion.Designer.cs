namespace Parking
{
    partial class configuracion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.botonAplicar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblPlazas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.botonAplicar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lblPlazas);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 404);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // botonAplicar
            // 
            this.botonAplicar.Location = new System.Drawing.Point(203, 349);
            this.botonAplicar.Name = "botonAplicar";
            this.botonAplicar.Size = new System.Drawing.Size(75, 23);
            this.botonAplicar.TabIndex = 3;
            this.botonAplicar.Text = "Aplicar";
            this.botonAplicar.UseVisualStyleBackColor = true;
            this.botonAplicar.Click += new System.EventHandler(this.botonAplicar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(203, 179);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 26);
            this.txtCantidad.TabIndex = 1;
            // 
            // lblPlazas
            // 
            this.lblPlazas.AutoSize = true;
            this.lblPlazas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlazas.Location = new System.Drawing.Point(29, 179);
            this.lblPlazas.Name = "lblPlazas";
            this.lblPlazas.Size = new System.Drawing.Size(168, 20);
            this.lblPlazas.TabIndex = 0;
            this.lblPlazas.Text = "Cantidad de plazas:";
            // 
            // configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 404);
            this.Controls.Add(this.panel1);
            this.Name = "configuracion";
            this.Text = "configuracion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblPlazas;
        private System.Windows.Forms.Button botonAplicar;
        private System.Windows.Forms.Button button1;
    }
}