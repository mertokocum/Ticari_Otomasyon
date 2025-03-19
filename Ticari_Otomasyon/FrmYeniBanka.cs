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
    public partial class FrmYeniBanka : Form
    {
        public FrmYeniBanka()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void FrmYeniBanka_Load(object sender, EventArgs e)
        {
            sehirlistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBankaAdı.Text);
            komut.Parameters.AddWithValue("@p2", Cmbil.Text);
            komut.Parameters.AddWithValue("@p3", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p4", TxtSube.Text);
            komut.Parameters.AddWithValue("@p5", TxtIban.Text);
            komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", TxtFirmaAdı.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
