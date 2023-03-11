using Guna.UI2.AnimatorNS;
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
using Controller = MARKET_OTOMASYON_SQL.controller.Controller;

namespace MARKET_OTOMASYON_SQL
{
    public partial class Eklemeform : Form
    {

        public Eklemeform()
        {
            InitializeComponent();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Eklemeform_Load(object sender, EventArgs e)
        {
            cmb_urunturu.Items.Add("baklagil");
            cmb_urunturu.Items.Add("meyve");
            cmb_urunturu.Items.Add("sebze");
            cmb_urunturu.Items.Add("et-süt");
            cmb_urunturu.SelectedIndex = 0;
        }

        private void txt_fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_miktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_miktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_urunekle_Click(object sender, EventArgs e)
        {
           Controller controller = new Controller();
            tumurunler tumurunler1 = new tumurunler();
            tumurunler1.barkodkod = txt_barkodkod.Text;
            tumurunler1.urunisim = txt_urunisim.Text;
            tumurunler1.fiyat =Convert.ToInt32(txt_fiyat.Text);
            tumurunler1.kilo = Convert.ToInt32(txt_miktar.Text);
            tumurunler1.urunturu = cmb_urunturu.SelectedItem.ToString();

           loginstatus sonuc=controller.urunekle(tumurunler1);
            if(sonuc==loginstatus.basarili)
            {
                MessageBox.Show("Ürün Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürün Eklenemedi.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
