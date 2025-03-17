using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Configuration;


namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMailAdres.Text = mail;
        }
        

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            string v = ConfigurationManager.AppSettings["SMTP_EMAIL"];
            string smtpEmail = v;
            string v1 = ConfigurationManager.AppSettings["SMTP_PASSWORD"];
            string smtpPassword = v1;

            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.UseDefaultCredentials = false;
            istemci.Credentials = new NetworkCredential(v,v1);
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            
            mesaj.To.Add(TxtMailAdres.Text);
            mesaj.From = new MailAddress(v);
            mesaj.Subject = TxtKonu.Text;
            mesaj.Body = TxtMesaj.Text;
            istemci.Send(mesaj);
        }
    }
}
