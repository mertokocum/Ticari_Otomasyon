using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void giderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderListesi();
        }
        void temizle()
        {
            CmbAy.Text = "";
            CmbYil.Text = "";
            TxtDogalgaz.Text = "";
            TxtElektrik.Text = "";
            TxtExtralar.Text = "";
            TxtID.Text = "";
            TxtInternet.Text = "";
            TxtMaaslar.Text = "";
            TxtSu.Text = "";
            RchNotlar.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            FrmYeniGider yeniGiderFormu = new FrmYeniGider();
            yeniGiderFormu.ShowDialog(); // Modally form açılır

            // Yeni kullanıcı eklenip form kapandığında listeyi güncelle
            giderListesi();
            temizle();
        }
    }
}
