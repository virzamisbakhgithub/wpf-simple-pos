using SLRDbConnector;
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
    public partial class Form_ProyekBerjalan : Form
    {
        public string kode { get; set; }
        public string nama { get; set; }


        DbConnector db;
        public Form_ProyekBerjalan()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void cmbKontraktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string alamat;
            db.getSingleValue("select Alamat from tblKontraktor where Nama = '" + cmbKontraktor.SelectedItem.ToString() + "'", out alamat, 0);
            txtAlamat.Text = alamat;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_ProyekBerjalan_Load(object sender, EventArgs e)
        {
            db.FillCombobox("select Nama from tblKontraktor", cmbKontraktor);
            txtNamaProyek.Text = nama;
        }

        string KontraktorId;
        private void cmbKontraktor_Leave(object sender, EventArgs e)
        {
            db.getSingleValue("select id from tblKontraktor where Nama = '" + cmbKontraktor.Text + "' and Alamat = '" + txtAlamat.Text + "'", out KontraktorId, 0);

            if (KontraktorId == null)
            {
                MessageBox.Show("Kontraktor tidak ditemukan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {

            }
        }

        private bool isFormValid()
        {
            if (KontraktorId == null)
            {
                MessageBox.Show("Kontraktor tidak ditemukan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbKontraktor.Text.Trim() == string.Empty || txtHarga.Text.Trim() == string.Empty || txtTanggal.Text.Trim() == string.Empty || cmbTahun.Text.Trim() == string.Empty)
            { MessageBox.Show("Harap isi semua kolom yang tersedia...", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 
            else
                return true;
        }
    }
}
