﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Parking
{
    public partial class historial : Form
    {
        public historial()
        {
            InitializeComponent();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);




        private void historial_Load(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();
           
            dgvHistorial.DataSource = conexiones.historial();


            for (int i = 0; i < dgvHistorial.RowCount -1; i++)
            {
                if (dgvHistorial.Rows[i].Cells[6].Value.ToString() == "0")
                {
                    dgvHistorial.Rows[i].Cells[6].Style.ForeColor = Color.White;
                    dgvHistorial.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.FromArgb(255, 79, 87); 
                }
                else
                {
                    dgvHistorial.Rows[i].Cells[6].Style.ForeColor = Color.White;
                    dgvHistorial.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.FromArgb(110, 177, 64);
                }

            }
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
