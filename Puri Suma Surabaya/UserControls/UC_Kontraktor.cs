using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLRDbConnector;

namespace Login_01.UserControls
{
    public partial class UC_Kontraktor : UserControl
    {
        DbConnector db;
        public UC_Kontraktor()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void btnSave_Click(object sender, EventArgs e) //tombol save kontraktor
        {
            if (isFormValid())
            {
                DialogResult dialog = MessageBox.Show("Apakah data sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    db.performCRUD("insert into tblKontraktor (Nama, Alamat) values('" + txtNama.Text + "','" + txtAlamat.Text + "')");
                    MessageBox.Show("Kontraktor berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNama.Clear();
                    txtAlamat.Clear();
                    this.OnLoad(e);
                }
            }
        }

        private bool isFormValid() //verifikasi data field kosong
        {
            if (txtNama.Text.Trim() == string.Empty || txtAlamat.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Harap isi semua kolom yang tersedia..", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UC_Kontraktor_Load(object sender, EventArgs e) //menampilkan db Tabel Kontraktor ke gridview
        {
            db.fillDataGridView("select * from tblKontraktor", dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //sortir data untuk pencarian
        {
            string query = "";
            if(cmbSortir.SelectedItem.ToString().Equals("ID"))
            {
                query = "select * from tblKontraktor where id = '" + txtSortir.Text + "'";
            }
            else if(cmbSortir.SelectedItem.ToString().Equals("Nama"))
            {
                query = "select * from tblKontraktor where Nama like '%" + txtSortir.Text + "%'";
            }
            else if(cmbSortir.SelectedItem.ToString().Equals("Alamat"))
            {
                query = "select * from tblKontraktor where Alamat like '%" + txtSortir.Text + "%'";
            }

            db.fillDataGridView(query, dataGridView1);

            if(txtSortir.Text == "")
            {
                this.OnLoad(e);
            }
        }

        string kontractorId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //selector data
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                kontractorId = item.Cells[0].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) //tombol hapus kontraktor
        {
            DialogResult dialog = MessageBox.Show("Anda yakin ingin menghapus kontraktor ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (!kontractorId.Equals(string.Empty))
                {
                    db.performCRUD("delete from tblKontraktor where id = '" + kontractorId + "'");
                    MessageBox.Show("Kontraktor berhasil dihapus");
                    this.OnLoad(e);
                }
            }
        }
    }
}
