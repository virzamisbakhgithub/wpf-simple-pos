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
    public partial class Form_TambahProyek : Form
    {
        DbConnector db;
        public Form_TambahProyek()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void Form_TambahProyek_Load(object sender, EventArgs e) //memanggil data dari db untuk field combobox
        {
            db.FillCombobox("select Nama from tblJenisPekerjaan", cmbJenisPekerjaan);
        }

        private void btnSave_Click(object sender, EventArgs e) //tombol save proyek
        {
            if (isFormValid())
            {
                insertValues();
            }
        }

        private void insertValues() //input data baru ke database
        {
            DialogResult dialogResult = MessageBox.Show("Apakah data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string tipe_pekerjaan = db.getSingleValue("select id from tblJenisPekerjaan where Nama = '" + cmbJenisPekerjaan.Text + "'", out tipe_pekerjaan, 0);
                db.performCRUD("insert into tblProyek (Proyek, Kode, Lokasi, Customer, Telp) Values('" + txtProyek.Text + "','" + tipe_pekerjaan + "','" + txtLokasi.Text + "','" + txtCustomer.Text + "','" + txtTelp.Text + "')");
                MessageBox.Show("Menambah proyek berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose(); //langsung menutup form setelah menyimpan data
            }
        }

        private bool isFormValid() //verifikasi field kosong
        {
            if (txtProyek.Text.Trim() == string.Empty
                || txtLokasi.Text.Trim() == string.Empty
                || txtCustomer.Text.Trim() == string.Empty
                || txtTelp.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Harap isi semua kolom yang tersedia...", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            else {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
