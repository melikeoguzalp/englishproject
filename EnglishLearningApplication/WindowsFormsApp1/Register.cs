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
    public partial class Register : Form
    {
        string Gender = "";
        public Register()
        {
            InitializeComponent();
           
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=UserDB;Integrated Security=True;Encrypt=False");
        private void RgstrBtn_Click(object sender, EventArgs e)
        {
            if (rbKadın.Checked == true)
            {
                Gender = "Female";
            }
            if (rbErkek.Checked == true)
            {
                Gender = "Male";
            }
            DateTime dob = dateTimePicker1.Value;
            SqlCommand cmdAdd = new SqlCommand("Insert into UserDB(Name,Surname,Email,Password,DateofBirth,Gender) Values(@ad,@ad2,@email,@psswd,@dob,@gender)", con);

            cmdAdd.Parameters.AddWithValue("@ad", NameText.Text);
            cmdAdd.Parameters.AddWithValue("@ad2", SurnameText.Text);
            cmdAdd.Parameters.AddWithValue("@email", EmailText.Text);
            cmdAdd.Parameters.AddWithValue("@psswd", PsswdText.Text);
            cmdAdd.Parameters.AddWithValue("@dob", dob);
            cmdAdd.Parameters.AddWithValue("@gender", Gender);
            if (PsswdText.Text.Equals(PsswdText2.Text) && generateCodeText.Text.Equals(userCodeText.Text))
            {
                con.Open();

                cmdAdd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Başarıyla Kayıt olundu.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                enter enter = new enter();
                enter.Show();
                this.Hide();
            }
            else if (PsswdText.Text != PsswdText2.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }
            else if(PsswdText.Text=="")
            {
                MessageBox.Show("Bu alanlar Boş geçilemez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else if (PsswdText2.Text == "")
            {
                MessageBox.Show("Bu alanlar Boş geçilemez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else if (userCodeText.Text == "")
            {
                MessageBox.Show("Bu alanlar Boş geçilemez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }


            else if(generateCodeText.Text != userCodeText.Text)
            {
                MessageBox.Show("Doğrulama kodunu hatalı girdiniz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
           
            
            
           



            

            
           

            

        }

        private void Register_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.CodeGenerate(generateCodeText);
        }
    }
}
