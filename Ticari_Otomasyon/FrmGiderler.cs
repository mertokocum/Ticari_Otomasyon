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
            TxtEkstra.Text = "";
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
                TxtEkstra.Text = dr["EKSTRA"].ToString();
                RchNotlar.Text = dr["NOTLAR"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Seçim Yapmadınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand komutSil = new SqlCommand("Delete From TBL_GIDERLER where GIDERID=@p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", TxtID.Text);
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                giderListesi();
                MessageBox.Show("Gider silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Seçim Yapmadınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand komutGuncelle = new SqlCommand("Update TBL_GIDERLER set AY=@p1, YIL=@p2, ELEKTRIK=@p3, SU=@p4, DOGALGAZ=@p5, INTERNET=@p6, MAASLAR=@p7, EKSTRA=@p8, NOTLAR=@p9 where GIDERID=@p10", bgl.baglanti());

                komutGuncelle.Parameters.AddWithValue("@p1", CmbAy.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", CmbYil.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
                komutGuncelle.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
                komutGuncelle.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
                komutGuncelle.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
                komutGuncelle.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
                komutGuncelle.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
                komutGuncelle.Parameters.AddWithValue("@p9", RchNotlar.Text);
                komutGuncelle.Parameters.AddWithValue("@p10", TxtID.Text);
                komutGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                giderListesi();
                temizle();
            }
        }
    }
}
