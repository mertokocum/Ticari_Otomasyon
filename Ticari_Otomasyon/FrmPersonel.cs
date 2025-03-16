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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtID.Text = "";
            TxtMail.Text = "";
            MskTelefon1.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            MskTC.Text = "";
            TxtGorev.Text = "";
            RchAdres.Text = "";

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

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
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
                        "insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,GOREV,ADRES) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",
                        bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                komut.Parameters.AddWithValue("@p4", MskTC.Text);
                komut.Parameters.AddWithValue("@p5", TxtMail.Text);
                komut.Parameters.AddWithValue("@p6", Cmbil.Text);
                komut.Parameters.AddWithValue("@p7", Cmbilce.Text);
                komut.Parameters.AddWithValue("@p8", TxtGorev.Text);
                komut.Parameters.AddWithValue("@p9", RchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            
            
        }

        private void gridView1_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Seçim Yapmadınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // PERSONEL adını çekmek için bir SQL sorgusu
                string personelAdi = "";
                SqlCommand komut = new SqlCommand("SELECT AD FROM TBL_PERSONELLER WHERE ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);

                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        personelAdi = dr["Ad"].ToString(); // 'Ad' sütunu müşteri adını içeriyor, bu isim sizin veritabanınıza bağlı olarak değişebilir
                    }
                }
                bgl.baglanti().Close();

                // Kullanıcıdan onay almak için MessageBox kullan, müşteri adını göster
                var result = MessageBox.Show(personelAdi + " isimli personeli silmek istediğinizden emin misiniz?", "Personel Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Eğer kullanıcı 'Evet' cevabını verirse
                if (result == DialogResult.Yes)
                {
                    // personel silme işlemini gerçekleştir
                    SqlCommand komutSil = new SqlCommand("Delete from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", TxtID.Text);
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Personel silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    listele();
                    temizle();
                }
                // Eğer kullanıcı 'Hayır' cevabını verirse, işlem yapma
                else if (result == DialogResult.No)
                {
                    // Hiçbir şey yapma
                }
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
                SqlCommand komut = new SqlCommand("update TBL_PERSONELLER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,GOREV=@P8,ADRES=@P9 where ID=@P10", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                komut.Parameters.AddWithValue("@p4", MskTC.Text);
                komut.Parameters.AddWithValue("@p5", TxtMail.Text);
                komut.Parameters.AddWithValue("@p6", Cmbil.Text);
                komut.Parameters.AddWithValue("@p7", Cmbilce.Text);
                komut.Parameters.AddWithValue("@p8", TxtGorev.Text);
                komut.Parameters.AddWithValue("@p9", RchAdres.Text);
                komut.Parameters.AddWithValue("@p10", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
                temizle();
            }
            
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
