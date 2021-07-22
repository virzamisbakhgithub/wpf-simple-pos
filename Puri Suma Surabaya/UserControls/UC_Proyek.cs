using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_01.Forms;
using SLRDbConnector;

namespace Login_01.UserControls
{
    public partial class UC_Proyek : UserControl
    {
        DbConnector db;
        public UC_Proyek()
        {
            InitializeComponent();
            db = new DbConnector();
        }


        private void btnTambahProyek(object sender, EventArgs e)
        {
            using (Form_TambahProyek fw = new Form_TambahProyek())
            {
                fw.ShowDialog();
                this.OnLoad(e);
            }
        }


        private void UC_Proyek_Load(object sender, EventArgs e) //menampilkan db Tabel proyek yang ditambahkan dari form tambah proyek ke form proyek
        {
            db.fillDataGridView("select * from tblProyek", dataGridView1);
        }

        string proyekId, kode, nama;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //selector data 
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                proyekId = item.Cells[0].Value.ToString();
                kode = item.Cells[0].Value.ToString();
                nama = item.Cells[1].Value.ToString();
            }
        }

        private void txtSortir_TextChanged(object sender, EventArgs e) //sortir data untuk pencarian
        {
            string query = "";
            if(cmbSortir.SelectedItem.ToString().Equals("ID"))
            {
                query = "select * from tblProyek where id = '" + txtSortir.Text + "'";
            }
            if(cmbSortir.SelectedItem.ToString().Equals("Kode"))
            {
                query = "select * from tblProyek where Kode like '%" + txtSortir.Text + "%'";
            }
            if(cmbSortir.SelectedItem.ToString().Equals("Lokasi"))
            {
                query = "select * from tblProyek where Lokasi like '%" + txtSortir.Text + "%'";
            }
            if(cmbSortir.SelectedItem.ToString().Equals("Nama Customer"))
            {
                query = "select * from tblProyek where Customer like '%" + txtSortir.Text + "%'";
            }
            if(cmbSortir.SelectedItem.ToString().Equals("Telp"))
            {
                query = "select * from tblProyek where Telp like '%" + txtSortir.Text + "%'";
            }

            db.fillDataGridView(query, dataGridView1);


            if(txtSortir.Text == "")
            {
                this.OnLoad(e);
            }


        }

        private void btnProyekBerjalan(object sender, EventArgs e)
        {
           if(kode != null)
            {
                Form_ProyekBerjalan fw = new Form_ProyekBerjalan();
                fw.kode = kode;
                fw.nama = nama;
                fw.ShowDialog();
                this.OnLoad(e);
            }
        }
    }
}
