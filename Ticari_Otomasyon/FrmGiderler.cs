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
            temizle();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["GIDERID"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYil.Text = dr["YIL"].ToString();
                TxtElektrik.Text = dr["ELEKTRIK"].ToString();
                TxtSu.Text = dr["SU"].ToString();
                TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                TxtInternet.Text = dr["INTERNET"].ToString();
                TxtMaaslar.Text = dr["MAASLAR"].ToString();
                TxtExtralar.Text = dr["EKSTRA"].ToString();
                RchNotlar.Text = dr["NOTLAR"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
