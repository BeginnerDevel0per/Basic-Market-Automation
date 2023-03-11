using MARKET_OTOMASYON_SQL.controller;
using MARKET_OTOMASYON_SQL.enumaration;
using MARKET_OTOMASYON_SQL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARKET_OTOMASYON_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            label1.BackColor = Color.Transparent;

            label2.BackColor = Color.Transparent;

            label3.BackColor = Color.Transparent;

            label4.BackColor = Color.Transparent;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            user result = controller.login(txt_kullaniciadi.Text, txt_sifre.Text);
            if (result != null && result.status == loginstatus.basarili && result.yetki == "admin")
            {
                adminpanel adminpanel = new adminpanel();
                adminpanel.Show();
                this.Hide();

            }
            else if (result != null && result.status == loginstatus.basarili && result.yetki == "kasiyer")
            {
                kasiyerpanel kasiyerpanel = new kasiyerpanel();
                kasiyerpanel.Show();
                this.Hide();

            }
            else if(result != null && result.status == loginstatus.basarisiz )
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş bırakılamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            sifredegistirme sd = new sifredegistirme();
            sd.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
