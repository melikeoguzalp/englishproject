namespace WindowsFormsApp1
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.KalıplarBtn = new System.Windows.Forms.Button();
            this.KelimelerBtn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Teal;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(111, 22);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(470, 261);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // KalıplarBtn
            // 
            this.KalıplarBtn.BackColor = System.Drawing.Color.Teal;
            this.KalıplarBtn.Location = new System.Drawing.Point(492, 355);
            this.KalıplarBtn.Margin = new System.Windows.Forms.Padding(2);
            this.KalıplarBtn.Name = "KalıplarBtn";
            this.KalıplarBtn.Size = new System.Drawing.Size(109, 59);
            this.KalıplarBtn.TabIndex = 2;
            this.KalıplarBtn.Text = "KALIPLAR";
            this.KalıplarBtn.UseVisualStyleBackColor = false;
            // 
            // KelimelerBtn
            // 
            this.KelimelerBtn.BackColor = System.Drawing.Color.Teal;
            this.KelimelerBtn.Location = new System.Drawing.Point(111, 355);
            this.KelimelerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.KelimelerBtn.Name = "KelimelerBtn";
            this.KelimelerBtn.Size = new System.Drawing.Size(113, 59);
            this.KelimelerBtn.TabIndex = 3;
            this.KelimelerBtn.Text = "KELİMELER\r\n";
            this.KelimelerBtn.UseVisualStyleBackColor = false;
            this.KelimelerBtn.Click += new System.EventHandler(this.KelimelerBtn_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(716, 438);
            this.Controls.Add(this.KelimelerBtn);
            this.Controls.Add(this.KalıplarBtn);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "menu";
            this.Text = "menu";
            this.Load += new System.EventHandler(this.menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button KalıplarBtn;
        private System.Windows.Forms.Button KelimelerBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}