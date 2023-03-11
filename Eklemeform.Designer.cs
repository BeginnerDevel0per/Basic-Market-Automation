namespace MARKET_OTOMASYON_SQL
{
    partial class Eklemeform
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_barkodkod = new System.Windows.Forms.TextBox();
            this.txt_urunisim = new System.Windows.Forms.TextBox();
            this.txt_miktar = new System.Windows.Forms.TextBox();
            this.txt_fiyat = new System.Windows.Forms.TextBox();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.btn_urunekle = new System.Windows.Forms.Button();
            this.cmb_urunturu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod kodu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün isim :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Miktar :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fiyat :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ürün türü :";
            // 
            // txt_barkodkod
            // 
            this.txt_barkodkod.Location = new System.Drawing.Point(126, 28);
            this.txt_barkodkod.Name = "txt_barkodkod";
            this.txt_barkodkod.Size = new System.Drawing.Size(125, 22);
            this.txt_barkodkod.TabIndex = 5;
            // 
            // txt_urunisim
            // 
            this.txt_urunisim.Location = new System.Drawing.Point(126, 57);
            this.txt_urunisim.Name = "txt_urunisim";
            this.txt_urunisim.Size = new System.Drawing.Size(125, 22);
            this.txt_urunisim.TabIndex = 6;
            // 
            // txt_miktar
            // 
            this.txt_miktar.Location = new System.Drawing.Point(126, 86);
            this.txt_miktar.Name = "txt_miktar";
            this.txt_miktar.Size = new System.Drawing.Size(125, 22);
            this.txt_miktar.TabIndex = 7;
            this.txt_miktar.TextChanged += new System.EventHandler(this.txt_miktar_TextChanged);
            this.txt_miktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_miktar_KeyPress);
            // 
            // txt_fiyat
            // 
            this.txt_fiyat.Location = new System.Drawing.Point(126, 115);
            this.txt_fiyat.Name = "txt_fiyat";
            this.txt_fiyat.Size = new System.Drawing.Size(125, 22);
            this.txt_fiyat.TabIndex = 8;
            this.txt_fiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fiyat_KeyPress);
            // 
            // btn_cikis
            // 
            this.btn_cikis.Location = new System.Drawing.Point(12, 297);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(102, 47);
            this.btn_cikis.TabIndex = 14;
            this.btn_cikis.Text = "ÇIKIŞ";
            this.btn_cikis.UseVisualStyleBackColor = true;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // btn_urunekle
            // 
            this.btn_urunekle.Location = new System.Drawing.Point(200, 297);
            this.btn_urunekle.Name = "btn_urunekle";
            this.btn_urunekle.Size = new System.Drawing.Size(102, 47);
            this.btn_urunekle.TabIndex = 15;
            this.btn_urunekle.Text = "EKLE";
            this.btn_urunekle.UseVisualStyleBackColor = true;
            this.btn_urunekle.Click += new System.EventHandler(this.btn_urunekle_Click);
            // 
            // cmb_urunturu
            // 
            this.cmb_urunturu.FormattingEnabled = true;
            this.cmb_urunturu.Location = new System.Drawing.Point(126, 144);
            this.cmb_urunturu.Name = "cmb_urunturu";
            this.cmb_urunturu.Size = new System.Drawing.Size(121, 24);
            this.cmb_urunturu.TabIndex = 16;
            this.cmb_urunturu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Eklemeform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(314, 372);
            this.Controls.Add(this.cmb_urunturu);
            this.Controls.Add(this.btn_urunekle);
            this.Controls.Add(this.btn_cikis);
            this.Controls.Add(this.txt_fiyat);
            this.Controls.Add(this.txt_miktar);
            this.Controls.Add(this.txt_urunisim);
            this.Controls.Add(this.txt_barkodkod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Eklemeform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eklemeform";
            this.Load += new System.EventHandler(this.Eklemeform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_barkodkod;
        private System.Windows.Forms.TextBox txt_urunisim;
        private System.Windows.Forms.TextBox txt_miktar;
        private System.Windows.Forms.TextBox txt_fiyat;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.Button btn_urunekle;
        private System.Windows.Forms.ComboBox cmb_urunturu;
    }
}