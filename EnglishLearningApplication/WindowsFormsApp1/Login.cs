using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{

    public partial class Login : Form
    {
        public int UserID { get; private set; } = 0;
        public void CodeGenerate(TextBox textBox) //Doğrulama kodu
        {
            Random random = new Random();
            int sayi = random.Next(10000, 100000);
            textBox.Text = sayi.ToString();
        }
        public Login()
        {
            InitializeComponent();
        }
        private void grişsayfası_Load(object sender, EventArgs e)
        {
            CodeGenerate(generationcodetext);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginSystem(usertextbox.Text, psswrdtextbox.Text))
            {
                if (codetext.Text.Equals(generationcodetext.Text)){
                    menu form = new menu(UserID);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Doğrulama kodunu yanlış girdiniz");
                    
                }
               
            }
            
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }

        public bool LoginSystem(string email, string password) //Kullanıcının veritabanındaki bilgilerini kontrol eder
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=UserDB;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand loginCommand = new SqlCommand("Select * from UserDB where Email=@email and Password = @password", con);
                loginCommand.Parameters.AddWithValue("@email", email);
                loginCommand.Parameters.AddWithValue("@password", password);

                con.Open();

                SqlDataReader reader = loginCommand.ExecuteReader();
               



                if (reader.Read())
                {
                    UserID = (int)reader["ID"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
            private void RegisterButton_Click(object sender, EventArgs e)
            {
                Register register = new Register();
                register.Show();
                this.Hide();
            }

    }
}
