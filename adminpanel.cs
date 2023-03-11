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
    public partial class adminpanel : Form
    {
        controller.Controller controller;
        public adminpanel()
        {
            InitializeComponent();
        }

        private void show_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_tumurunler_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            controller = new controller.Controller();
            DataGridView1.DataSource = controller.getlogintable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            panel6.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();

        }

        private void adminpanel_Load(object sender, EventArgs e)
        {

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            cmb_gncguvenliksorusu.Items.Add("En sevdiğiniz hayvan nedir?");
            cmb_gncguvenliksorusu.Items.Add("En sevdiğiniz araba?");
            cmb_gncyetki.Items.Add("admin");
            cmb_gncyetki.Items.Add("kasiyer");
            cmb_guvenliksoru.Items.Add("En sevdiğiniz hayvan nedir?");
            cmb_guvenliksoru.Items.Add("En sevdiğiniz araba?");
            cmb_yetki.Items.Add("admin");
            cmb_yetki.Items.Add("kasiyer");
            cmb_guvenliksoru.SelectedIndex = 0;
            cmb_yetki.SelectedIndex = 0;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            controller = new controller.Controller();
            user user = new user();
            user.emailadres = txt_eposta.Text;
            user.kullaniciadi = txt_kullaniciadi.Text;
            user.yetki = cmb_yetki.SelectedItem.ToString(); ;
            user.guvenlikcevap = txt_guvenlikcevap.Text;
            user.guvenliksoru = cmb_guvenliksoru.SelectedItem.ToString();
            user.sifre = txt_sifre.Text;
            loginstatus result = controller.kullaniciekle(user);
            if (result == loginstatus.basarili)
            {
                MessageBox.Show("Kullanıcı eklendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kullanıcı eklenemedi...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cikis == DialogResult.Yes)
            {
                loginstatus result = controller.kullanicisil(Convert.ToInt32(txt_silid.Text));
                if (result == loginstatus.basarili)
                {
                    MessageBox.Show("Kullanıcı silindi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlem başarısız.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Güncellemek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cikis == DialogResult.Yes)
            {
                user user = new user();
                user.id = Convert.ToInt32(txt_gncid.Text);
                user.emailadres = txt_gnceposta.Text;
                user.sifre = txt_gncsifre.Text;
                user.kullaniciadi = txt_gnckullaniciadi.Text;
                user.yetki = cmb_gncyetki.SelectedItem.ToString();
                user.guvenliksoru = cmb_guvenliksoru.SelectedItem.ToString();
                user.guvenlikcevap = txt_guvenlikcevabı.Text;

                loginstatus result = controller.kullaniciguncelle(user);
                if (result == loginstatus.basarili)
                {
                    MessageBox.Show("Kullanıcı güncellendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlem başarısız.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataGridView1.DataSource = controller.getlogintable();
            }
            else
            {

            }


        }

        private void btn_guncelle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_gncid.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_gnckullaniciadi.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_gncsifre.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_gnceposta.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmb_gncguvenliksorusu.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            cmb_gncyetki.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_guvenlikcevabı.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            panel6.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            panel6.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            panel5.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kasiyerpanel kasiyerpanel = new kasiyerpanel();
            kasiyerpanel.Show();
            kasiyerpanel.geri.Show();
            panel6.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Show();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
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
    }
}
