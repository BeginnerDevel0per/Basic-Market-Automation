using AForge.Video.DirectShow;
using Guna.UI2.AnimatorNS;
using MARKET_OTOMASYON_SQL.controller;
using MARKET_OTOMASYON_SQL.dao;
using MARKET_OTOMASYON_SQL.enumaration;
using MARKET_OTOMASYON_SQL.model;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Controller = MARKET_OTOMASYON_SQL.controller.Controller;

namespace MARKET_OTOMASYON_SQL
{
    public partial class kasiyerpanel : Form
    {
        Controller controller = new Controller();
        int sayi1;
        int sayi2;
        int islemtip;
        public kasiyerpanel()
        {
            InitializeComponent();
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
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        private void kasiyerpanel_Load(object sender, EventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo camera in fic)
            {
                comboBox1.Items.Add(camera.Name);
            }
            comboBox1.SelectedIndex = 0;
            geri.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Show();
            btn_tumurunler.PerformClick();


        }

        public void button1_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            

            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            dataGridView1.DataSource = controller.GetBaklagilgetirs();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            dataGridView1.DataSource = controller.GetMeyvegetirs();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
           
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            panel5.Hide();
            panel6.Hide();
            dataGridView1.DataSource = controller.GetSebzegetirs();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
           
            
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Show();
            panel6.Hide();
            dataGridView1.DataSource = controller.GetEtsutgetirs();

        }

        private void secilentus(object sender, EventArgs e)
        {
            if (txt_hspmakinesi.Text == "0")
            {
                txt_hspmakinesi.Text = "";
            }
            txt_hspmakinesi.Text += ((Button)sender).Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txt_hspmakinesi.Text = "0";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            islemtip = 1;
            sayi1 = Convert.ToInt32(txt_hspmakinesi.Text);
            txt_hspmakinesi.Text = "0";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (islemtip == 1)
            {
                sayi2 = Convert.ToInt32(txt_hspmakinesi.Text);
                txt_hspmakinesi.Text = (sayi1 + sayi2).ToString();
            }
            else if (islemtip == 2)
            {
                sayi2 = Convert.ToInt32(txt_hspmakinesi.Text);
                txt_hspmakinesi.Text = (sayi1 - sayi2).ToString();
            }
            else if (islemtip == 3)
            {
                sayi2 = Convert.ToInt32(txt_hspmakinesi.Text);
                txt_hspmakinesi.Text = (sayi1 * sayi2).ToString();
            }
            else if (islemtip == 4)
            {
                sayi2 = Convert.ToInt32(txt_hspmakinesi.Text);
                txt_hspmakinesi.Text = (sayi1 / sayi2).ToString();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            islemtip = 2;
            sayi1 = Convert.ToInt32(txt_hspmakinesi.Text);
            txt_hspmakinesi.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            islemtip = 3;
            sayi1 = Convert.ToInt32(txt_hspmakinesi.Text);
            txt_hspmakinesi.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            islemtip = 4;
            sayi1 = Convert.ToInt32(txt_hspmakinesi.Text);
            txt_hspmakinesi.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
            vcd.NewFrame += Vcd_NewFrame;
            vcd.Start();
            timer1.Start();
            pictureBox1.Visible = true;

        }

        private void Vcd_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            vcd.Stop();
            pictureBox1.Visible = false;

        }

        private void button24_Click(object sender, EventArgs e)
        {
            Eklemeform eklemeform = new Eklemeform();
            eklemeform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_urunsil_Click(object sender, EventArgs e)
        {




        }

        private void btn_urunsilmeyve_Click(object sender, EventArgs e)
        {



        }

        private void btn_urunsilsebze_Click(object sender, EventArgs e)
        {

            Controller controller = new Controller();
            controller.urunsil(Convert.ToInt32(txt_urunsil.Text));

            dataGridView1.DataSource = controller.gettumurunler();
        }

        private void btn_urunsiletsut_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureBox1.Image);

                if (result != null)
                {
                    textBox1.Text = result.ToString();

                }




            }
        }

        public void btn_tumurunler_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
           

            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Show();
            dataGridView1.DataSource = controller.gettumurunler();


        }

        private void btn_urunarama_Click(object sender, EventArgs e)
        {
            urunarama urunarama = new urunarama();
            urunarama.urunturu = txt_urunarama.Text;
            urunarama.barkodkod = txt_urunarama.Text;
            urunarama.urunisim = txt_urunarama.Text;
            /*
            urunarama.fiyat =Convert.ToInt32(txt_urunarama.Text);
            urunarama.kilo=Convert.ToInt32(txt_urunarama.Text);
            */
            dataGridView1.DataSource = controller.GetUrunaramas(urunarama);
            

        }
        int move;
        int Mouse_X;
        int Mouse_Y;
        private void kasiyerpanel_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void kasiyerpanel_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void kasiyerpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_urunarama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_urunarama.PerformClick();
                txt_urunarama.Clear();


            }
        }
        private void txt_urunarama_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txt_urunarama_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

         private void geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
