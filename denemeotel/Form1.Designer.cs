namespace denemeotel
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;

     
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtEposta = new System.Windows.Forms.Label();
            this.txtsifre = new System.Windows.Forms.Label();
            this.TxtKullanıcıAdı = new System.Windows.Forms.TextBox();
            this.TxtSifreGiris = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEposta
            // 
            this.txtEposta.AutoSize = true;
            this.txtEposta.BackColor = System.Drawing.Color.Transparent;
            this.txtEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEposta.Location = new System.Drawing.Point(349, 61);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(96, 16);
            this.txtEposta.TabIndex = 0;
            this.txtEposta.Text = "Kullanıcı Adı:";
            this.txtEposta.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtsifre
            // 
            this.txtsifre.AutoSize = true;
            this.txtsifre.BackColor = System.Drawing.Color.Transparent;
            this.txtsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsifre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtsifre.Location = new System.Drawing.Point(349, 125);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(43, 16);
            this.txtsifre.TabIndex = 1;
            this.txtsifre.Text = "Şifre:";
            this.txtsifre.Click += new System.EventHandler(this.label2_Click);
            // 
            // TxtKullanıcıAdı
            // 
            this.TxtKullanıcıAdı.BackColor = System.Drawing.Color.Tan;
            this.TxtKullanıcıAdı.Location = new System.Drawing.Point(352, 90);
            this.TxtKullanıcıAdı.Name = "TxtKullanıcıAdı";
            this.TxtKullanıcıAdı.Size = new System.Drawing.Size(174, 22);
            this.TxtKullanıcıAdı.TabIndex = 2;
            this.TxtKullanıcıAdı.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TxtSifreGiris
            // 
            this.TxtSifreGiris.BackColor = System.Drawing.Color.Tan;
            this.TxtSifreGiris.Location = new System.Drawing.Point(352, 155);
            this.TxtSifreGiris.Name = "TxtSifreGiris";
            this.TxtSifreGiris.Size = new System.Drawing.Size(174, 22);
            this.TxtSifreGiris.TabIndex = 3;
            this.TxtSifreGiris.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Bisque;
            this.btnGiris.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGiris.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Location = new System.Drawing.Point(367, 216);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(144, 47);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ayvalık\'taki Evinize Hoşgeldiniz..";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Keyifli Tatiller Dileriz..";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(576, 538);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.TxtSifreGiris);
            this.Controls.Add(this.TxtKullanıcıAdı);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.txtEposta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Yönetici Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtEposta;
        private System.Windows.Forms.Label txtsifre;
        private System.Windows.Forms.TextBox TxtKullanıcıAdı;
        private System.Windows.Forms.TextBox TxtSifreGiris;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

