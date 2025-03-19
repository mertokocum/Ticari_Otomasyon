using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Linq.Helpers;

namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
        }
        void temizle()
        {
            Cmbil.Text = "";
            Cmbilce.Text = "";
            TxtBankaAdı.Text = "";
            TxtFirmaAdı.Text = "";
            TxtHesapNo.Text = "";
            TxtID.Text = "";
            TxtHesapTuru.Text = "";
            TxtIban.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            FrmYeniBanka yeniBankaFormu = new FrmYeniBanka();
            yeniBankaFormu.ShowDialog(); // Modally form açılır

            // Yeni kullanıcı eklenip form kapandığında listeyi güncelle
            listele();
            temizle();
        }
    }
}
