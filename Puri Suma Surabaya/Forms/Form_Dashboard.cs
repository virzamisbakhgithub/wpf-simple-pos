using Login_01.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_01.Forms
{
    public partial class Form_Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public Form_Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            panelSide.Height = btnDashboard.Height; //penggerak panel samping menubar default di dashboard
            panelSide.Top = btnDashboard.Top; //penggerak panel samping menubar default di dashboard
        }

        private void timer1_Tick(object sender, EventArgs e) //fungsi panel bergeser menutup menubar
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 80; //kecepatan membuka 80ms
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 80; //kecepatan menutup 80ms
                if (panelLeft.Width <= 120) //
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timerTime_Tick(object sender, EventArgs e) //menampilkan waktu dan tanggal sesuai timezone server
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void button8_Click(object sender, EventArgs e) //button menutup dan membuka menubar
        {
            timer1.Start();
        }

        private void button9_Click(object sender, EventArgs e) //button menutup form kembali ke login page
        {
            this.Dispose();
        }

        private void addControls(UserControl uc)
        {
            panelControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelControls.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnDaftarProyek_Click(object sender, EventArgs e)
        {
            UC_Proyek up = new UC_Proyek();
            addControls(up);
            panelSide.Height = btnDaftarProyek.Height;
            panelSide.Top = btnDaftarProyek.Top;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_Dashboard ud = new UC_Dashboard();
            addControls(ud);
            panelSide.Height = btnDashboard.Height;
            panelSide.Top = btnDashboard.Top;
        }

        private void btnKontraktor_Click(object sender, EventArgs e)
        {
            UC_Kontraktor uc = new UC_Kontraktor();
            addControls(uc);
            panelSide.Height = btnKontraktor.Height;
            panelSide.Top = btnKontraktor.Top;
        }
    }
}
