using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.myapplication;

namespace WindowsFormsApp1
{
    public partial class WaitingPage : Form
    {
        public int UserID { get; private set; } = 0;
        public WaitingPage()
        {
            InitializeComponent();
        }
        private async void WaitingPage_Load(object sender, EventArgs e)
        {
            await intro();
        }

        public async Task intro()
        {
            for(int i = 3; i > 0; i--)
            {
                label1.Text = i.ToString();
               await Task.Delay(1000);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
