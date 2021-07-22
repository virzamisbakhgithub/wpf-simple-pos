using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLRDbConnector;
using Login_01.Forms;

namespace Login_01
{

    public partial class Form1 : Form
    {
        DbConnector db;

        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e) //button login click
        {
            if (isFormValid())
            {
                if (checkLogin())
                {
                    using (Form_Dashboard fd = new Form_Dashboard()) //shpw dashboard page
                    {
                        fd.ShowDialog();
                        txtUsername.Clear();
                        txtPassword.Clear();
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private bool checkLogin() //autentifikasi login username dan password ke database sqlserver
        {
            string username = db.getSingleValue("SELECT UserName FROM tblUsers WHERE UserName = '"+txtUsername.Text+"' AND Password = '"+txtPassword.Text+"'", out username, 0);
            if(username == null)
            {
                MessageBox.Show("Data yang anda masukkan salah, mohon periksa kembali!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormValid() //autentifikasi memastikan semua field terisi
        {
            if (txtUsername.Text.ToString().Trim() == string.Empty || txtPassword.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Mohon isi seluruh kolom yang dibutuhkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e) //button close click
        {
            Application.Exit();
        }
    }
}
