using MARKET_OTOMASYON_SQL.controller;
using MARKET_OTOMASYON_SQL.enumaration;
using MARKET_OTOMASYON_SQL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARKET_OTOMASYON_SQL
{
    public partial class sifredegistirme : Form
    {
        int dogrulama;
        public sifredegistirme()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            grpbx_sifredegistir.Enabled = false;
            panel1.Show();
            panel3.Hide();
            grpbx_mail.Hide();
            grpbx_gvnlik.Show();
        }

        private void sifredegistirme_Load(object sender, EventArgs e)
        {

            Controller controller = new Controller();
            List<logintable> logintablelist = controller.getlogintable();
            foreach (logintable lt in logintablelist)
            {
                cmb_gvnliksoru.Items.Add(lt.guvenliksoru.ToString());
            }
            cmb_gvnliksoru.SelectedIndex = 1;
            grpbx_sifredegistir.Enabled = false;
            grpbx_gvnlik.Hide();
            grpbx_mail.Hide();
            panel1.Hide();
            panel3.Hide();

        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            grpbx_sifredegistir.Enabled = false;
            panel1.Hide();
            panel3.Show();
            grpbx_mail.Show();
            grpbx_gvnlik.Hide();
        }

        private void btn_sorgula_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            loginstatus result = controller.doauthentication(txt_kullaniciadi.Text.Trim(), cmb_gvnliksoru.SelectedItem.ToString(), txt_gvnlikcevap.Text.ToLower());
            if (result == loginstatus.basarili)
            {
                grpbx_sifredegistir.Enabled = true;
            }
            else if (result == loginstatus.basarisiz)
            {
                MessageBox.Show("Girdiğiniz bilgiler hatalıdır. Kontrol ediniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Tüm alanları doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
           string emailadres= controller.kontrolemailadres(txt_kullaniciadimail.Text);
            if (emailadres == txt_mail.Text)
            {
                loginstatus result = controller.maildogrulama(txt_kullaniciadimail.Text.Trim(), txt_mail.Text);
                if (result == loginstatus.basarili)
                {
                    Random rdn = new Random();
                    dogrulama = rdn.Next(111111, 999999);


                    // ...

                    // E-posta gönderecek SMTP sunucusunun adresi
                    string smtpAddress = "smtp-mail.outlook.com";
                    // SMTP sunucusuna bağlanmak için kullanılacak port numarası
                    int portNumber = 587;
                    // E-posta gönderecek hesabın kullanıcı adı ve parolası
                    string username = "otomasyondeneme12345@hotmail.com";
                    string password = "otomasyon123456";

                    // Gönderilecek e-posta'nın bilgileri
                    string to = txt_mail.Text;
                    string from = "otomasyondeneme12345@hotmail.com";
                    string subject = "Şifre değişikliği";
                    string body = "şifre değiştirme kodunuz :" + dogrulama;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(from);
                        mail.To.Add(to);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        // E-posta içerisinde ek dosya eklemek isterseniz aşağıdaki satırı kullanabilirsiniz:
                        // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(username, password);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }


                    MessageBox.Show("Doğrulama kodu gönderildi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == loginstatus.basarisiz)
                {
                    MessageBox.Show("Girdiğiniz bilgiler hatalıdır. Kontrol ediniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Tüm alanları doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mail adresi bulunamadı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_dogrlamakodu.Text) == dogrulama)
            {

                grpbx_sifredegistir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Doğrulama kodunuz hatalı veya eksik.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void btn_sifredegistir_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            if (txt_yenisifre.Text == txt_yenisifretekrar.Text)
            {
                if (!string.IsNullOrEmpty(txt_kullaniciadi.Text))
                {
                   loginstatus result= controller.sifredegistirme(txt_kullaniciadi.Text, txt_yenisifre.Text);
                    if(result == loginstatus.basarili)
                    {
                        MessageBox.Show("Şifreniz değiştirilmiştir.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Boş bırakılamaz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!string.IsNullOrEmpty(txt_kullaniciadimail.Text))
                {
                   loginstatus result = controller.sifredegistirme(txt_kullaniciadimail.Text, txt_yenisifre.Text);
                    if (result == loginstatus.basarili)
                    {
                        MessageBox.Show("Şifreniz değiştirilmiştir.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Boş bırakılamaz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Farklı şifreler girilemez.Kontrol ediniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_kullaniciadimail_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_gvnliksoru_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
// sıra bu şekilde ilerliyor sifredeğiştirme-controller-repository 