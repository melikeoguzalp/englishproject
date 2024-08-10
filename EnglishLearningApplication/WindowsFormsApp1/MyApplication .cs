using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class myapplication : Form
    {
        public static int puan = 0;
        public string correctTurkishWord = "";
        public string labelWord = "";
        private Timer timer;
        private int progressValue = 0;
        int CheckPoint = 0;
        public FormMode mode;
        private int UserID;

        public myapplication(FormMode mode, int UserID)
        {
            this.mode = mode;
            this.UserID = UserID;
            InitializeComponent();
            InitializeTimer();
        }

        private async void myapplication_Load(object sender, EventArgs e)
        {
            LoadUserProgress(); // kullanıcının puanını yükler kaldığı yerden devam etmesi için
            LoadWordsByDifficulty(); // kelimeleri zorluğuna göre yazdırır
            timer.Start();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await CheckAnswer(button1);
            LoadWordsByDifficulty();
            progressBar1.Value = 0; 
            timer.Start();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await CheckAnswer(button2);
            LoadWordsByDifficulty();
            progressBar1.Value = 0;
            timer.Start();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await CheckAnswer(button3);
            LoadWordsByDifficulty();
            progressBar1.Value = 0;
            timer.Start();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await CheckAnswer(button4);
            LoadWordsByDifficulty();
            progressBar1.Value = 0;
            timer.Start();
        }

        private void LoadWordsByDifficulty()
        {
            if (mode == FormMode.Kelime)
            {
                PrintA1Words();

                if (puan >= 3800 && puan < 7600)
                {
                    MessageBox.Show("Tebrikler A2 seviyesine geçtiniz!");
                    PrintA2Words();
                }
                else if (puan >= 7600 && puan < 11400)
                {
                    MessageBox.Show("Tebrikler B1 ye geçtiniz!");
                    MessageBox.Show("Kalıplar seviyesinin kilidi açıldı!");
                    PrintB1Words();

                }
                else if (puan >= 11400 && puan < 15200)
                {
                    MessageBox.Show("Tebrikler B2 seviyesine geçtiniz!");
                    PrintB2Words();
                }
                else if (puan >= 15200)
                {
                    MessageBox.Show("Tebrikler C1 seviyesine geçtiniz!");
                    PrintC1Words();
                }
            }
            else if (mode == FormMode.Kaliplar)
            {
                printKaliplar();
            }
        }
        public enum FormMode
        {
            Kelime,
            Kaliplar
        }
        public void PrintA1Words()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(1, 400));
            GetTrueAnswer(1, 400);
        }

        public void PrintA2Words()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(400, 800));
            GetTrueAnswer(400, 800);
        }

        public void PrintB1Words()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(800, 1200));
            GetTrueAnswer(800, 1200);
        }

        public void PrintB2Words()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(1200, 1600));
            GetTrueAnswer(1200, 1600);
        }

        public void PrintC1Words()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(1600, 2343));
            GetTrueAnswer(1600, 2000);
        }

        public void printKaliplar()
        {
            SetButtonText(GetRandomTurkishWordFromDatabase(2344, 2504));
            GetTrueAnswer(2344, 2504);
        }

        public void SetButtonText(string[] words) 
            //random türkçe kelimelerin butonlara yazdırıldığı yer.
        {
            button1.Text = words[0];
            button2.Text = words[1];
            button3.Text = words[2];
            button4.Text = words[3];
        }

        public void RandomiseButton(string value)
        {
            // 4 tane butondan rastgele bir buton seçip ona doğru türkçe karşılığı olan kelimeyi atar.
            Random random = new Random();
            Button[] rndmbtn = new Button[4];
            rndmbtn[0] = button1;
            rndmbtn[1] = button2;
            rndmbtn[2] = button3;
            rndmbtn[3] = button4;

            Button selectedButton = rndmbtn[random.Next(0, rndmbtn.Length)];
            selectedButton.Text = value.ToString();
        }

        public string[] GetRandomTurkishWordFromDatabase(int startId, int endId) // Rastgele türkçe kelimeyi database'den çeker.
        {
            List<string> words = new List<string>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=KelimeDB;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand randomTurkishWordQuery = new SqlCommand($"SELECT * FROM Words WHERE ID BETWEEN {startId} AND {endId} ORDER BY NEWID()", con);
                SqlDataReader reader = randomTurkishWordQuery.ExecuteReader();

                while (reader.Read())
                {
                    words.Add(reader["Turkish"].ToString()); //türkçe kelime
                }

                reader.Close();
            }
            return words.ToArray(); // türkçe kelimeyi döndürür
        }

        List<string> kullanilanKelimeler = new List<string>(); //kullanılmış kelimeler bu listeye atanacak.
        public void GetTrueAnswer(int startId, int endId) // labeldaki ingilizce kelimeyi ve doğru türkçe karşılığını yazdırır.
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=KelimeDB;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand englishWordQuery = new SqlCommand($"SELECT * FROM Words WHERE ID BETWEEN {startId} AND {endId} ORDER BY NEWID()", con);
                SqlDataReader reader = englishWordQuery.ExecuteReader();

                reader.Read();

                correctTurkishWord = reader["Turkish"].ToString(); //türkçe
                labelWord = reader["English"].ToString(); //ingilice

                while (kullanilanKelimeler.Contains(labelWord)) // kullanılan kelimeler adlı liste labelword'deki kelimeyi içerirse döngüye devam eder.
                {
                    reader.Read();
                    correctTurkishWord = reader["Turkish"].ToString();
                    labelWord = reader["English"].ToString();
                }
                kullanilanKelimeler.Add(labelWord); // kullanılan kelimeyi içermezse atama işlemi gerçekleşir.

                label1.Text = labelWord; //ingilizce kelime label'a yazdırılır.
                RandomiseButton(correctTurkishWord); // random olarak 1 tane butona türkçe kelime yazdırılır.

                reader.Close();
            }
        }

        public async Task CheckAnswer(Button clickedButton)
        {
            bool isCorrect = string.Equals(clickedButton.Text, correctTurkishWord, StringComparison.OrdinalIgnoreCase);
            //tıklanan butondaki türkçe kelime ile labeldaki yazan ingilizcenin doğru karşılığı olan butondaki kelime karşılaştırılır.

            timer.Stop();
            SetButtonsEnabled(false); // tıklandıktan sonra butonlar inaktif olur.

            if (isCorrect)
            {
                if(mode == FormMode.Kelime)
                {
                    puan += 10;
                    label2.Text = "puan : " + puan;
                    CheckPoint += puan;
                    SaveProgress();
                }
               

                await HighlightButtons(clickedButton, true);
                timer.Start();
            }

            else
            {
                await HighlightButtons(clickedButton, false);
                timer.Start();
            }
            SetButtonsEnabled(true); //butonlar geri aktif olur.
        }

        public void SetButtonsEnabled(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button3.Enabled = enabled;
            button4.Enabled = enabled;
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 100; // ProgressBar'ı güncelleme aralığı (ms)
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer.Stop();
                LoadWordsByDifficulty();
                progressBar1.Value = 0; // ProgressBar'ı sıfırlayın
                timer.Start();
            }
        }

        public async Task HighlightButtons(Button clickedButton, bool isCorrect)
        {
            Button[] buttons = new Button[] { button1, button2, button3, button4 };

            if (isCorrect) // doğru ise ses çıkar ve buton yeşil yanar
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"ses.wav"); //doğru ses
                player.Play();
                clickedButton.BackColor = Color.Green; //butonu yeşil yap
            }
            else // aksi takdirde error sesi çıkar ve yanlış butonlar kırmızı yanıp doğru buton yeşil yanar.
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"error.wav"); //yanlış ses
                player.Play();
                foreach (Button button in buttons)
                {
                    if (button == clickedButton)
                    {
                        button.BackColor = Color.Red;
                    }
                    else if (button.Text == correctTurkishWord)
                    {
                        button.BackColor = Color.Green;
                    }
                    else
                    {
                        button.BackColor = Color.Red;
                    }
                }
            }
            await Task.Delay(2000); // 2sn bekletir

            foreach (Button button in buttons)
            {
                button.BackColor = SystemColors.Control; // default rengine geri döndürür.
            }
            

            
        }
        public void SaveProgress() // Kullanıcının puanını kaydeder
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-124HMGS\\MSSQLSERVER01;Initial Catalog=UserDB;Integrated Security=True;Encrypt=False"))
            {
                con.Open();
                SqlCommand saveProgressCmd = new SqlCommand("UPDATE UserDB SET point = @point WHERE ID = @ID", con);
                saveProgressCmd.Parameters.AddWithValue("@point", puan);
                saveProgressCmd.Parameters.AddWithValue("@ID", UserID);

                saveProgressCmd.ExecuteNonQuery();
            }
        }

        public void LoadUserProgress() //kullanıcının puanını yükler
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
                    puan = Convert.ToInt32(result);
                    label2.Text = "puan : " + puan;
                }
                else
                {
                    MessageBox.Show("null");
                }
                
            }
        }
    }
}
