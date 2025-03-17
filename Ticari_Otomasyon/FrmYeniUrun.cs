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

namespace Ticari_Otomasyon
{
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnSil_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapat
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Verileri kaydet
            SqlCommand komut =
                new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Formu kapat
        }
    }
}
