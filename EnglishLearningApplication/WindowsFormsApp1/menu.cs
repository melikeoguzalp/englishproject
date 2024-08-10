using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.myapplication;

namespace WindowsFormsApp1
{
    public partial class menu : Form
    {
        
        public int UserID { get; private set; } = 0;

        
        public menu(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            KalıplarBtn.Enabled = false;
        }
        
        private void menu_Load(object sender, EventArgs e)
        {
            LoadUserPoints();
        }

        public void KelimelerBtn_Click(object sender, EventArgs e)
        {

            WaitingPage form = new WaitingPage();
           if(form.ShowDialog() == DialogResult.OK)
            {
                myapplication kelimeForm = new myapplication(FormMode.Kelime,UserID);
                kelimeForm.Show();
            }
        }
        public void KaliplarBtn_Click(object sender, EventArgs e)
        {
            
            WaitingPage form = new WaitingPage();
            if (form.ShowDialog() == DialogResult.OK)
            {
                myapplication kaliplarForm = new myapplication(FormMode.Kaliplar,UserID);
                kaliplarForm.Show();
            }
            

        }

        private void LoadUserPoints() //Kullanıcının puanını veritabanından çekip kontrol eder ve belirli bir puanın üzerindeyse buton aktifleştirir.
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=UserDB;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT point FROM UserDB WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", UserID);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int points = Convert.ToInt32(result);
                    if (points >= 7600)
                    {
                        
                        KalıplarBtn.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı puanı yüklenemedi.");
                }
            }
        }


    }
}
