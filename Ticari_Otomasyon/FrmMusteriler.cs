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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }



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
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut =
                new SqlCommand(
                    "insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",
                    bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTC.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", Cmbil.Text);
            komut.Parameters.AddWithValue("@p8", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", RchAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // Müşteri adını çekmek için bir SQL sorgusu
            string musteriAdi = "";
            SqlCommand komut = new SqlCommand("SELECT Ad FROM TBL_MUSTERILER WHERE ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);

            using (SqlDataReader dr = komut.ExecuteReader())
            {
                if (dr.Read())
                {
                    musteriAdi = dr["Ad"].ToString(); // 'Ad' sütunu müşteri adını içeriyor, bu isim sizin veritabanınıza bağlı olarak değişebilir
                }
            }
            bgl.baglanti().Close();

            // Kullanıcıdan onay almak için MessageBox kullan, müşteri adını göster
            var result = MessageBox.Show(musteriAdi + " isimli müşteriyi silmek istediğinizden emin misiniz?", "Müşteri Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Eğer kullanıcı 'Evet' cevabını verirse
            if (result == DialogResult.Yes)
            {
                // Müşteri silme işlemini gerçekleştir
                SqlCommand komutSil = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", TxtID.Text);
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                listele();
            }
            // Eğer kullanıcı 'Hayır' cevabını verirse, işlem yapma
            else if (result == DialogResult.No)
            {
                // Hiçbir şey yapma
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,VERGIDAIRE=@P9,ADRES=@P10 where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTC.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", Cmbil.Text);
            komut.Parameters.AddWithValue("@p8", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", TxtVergi.Text);
            komut.Parameters.AddWithValue("@p10", RchAdres.Text);
            komut.Parameters.AddWithValue("@p11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
    }
}
