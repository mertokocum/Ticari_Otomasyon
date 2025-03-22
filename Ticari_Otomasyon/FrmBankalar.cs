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
        public void listele()
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
            sehirlistesi();
            firmaListesi();
        }
        public void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.NullText= "Lütfen Firma Seçiniz";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        public void temizle()
        {
            Cmbil.Text = "";
            Cmbilce.Text = "";
            TxtBankaAdı.Text = "";
            lookUpEdit1.Text = "";
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtBankaAdı.Text = dr["BANKAADI"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                TxtIban.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
                //lookUpEdit1.Text = dr["FIRMAID"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Banka Seçmediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // BANKA adını çekmek için bir SQL sorgusu
                string bankaAdi = "";
                SqlCommand adkomut = new SqlCommand("SELECT BANKAADI FROM TBL_BANKALAR WHERE ID=@p1", bgl.baglanti());
                adkomut.Parameters.AddWithValue("@p1", TxtID.Text);

                using (SqlDataReader dr = adkomut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bankaAdi = dr["BANKAADI"].ToString(); // 'Ad' sütunu müşteri adını içeriyor, bu isim sizin veritabanınıza bağlı olarak değişebilir
                    }
                }
                bgl.baglanti().Close();

                // Kullanıcıdan onay almak için MessageBox kullan, müşteri adını göster
                var result = MessageBox.Show(bankaAdi + " isimli bankayı silmek istediğinizden emin misiniz?", "Banka Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Eğer kullanıcı 'Evet' cevabını verirse
                if (result == DialogResult.Yes)
                {
                    // personel silme işlemini gerçekleştir
                    SqlCommand komut = new SqlCommand("delete from TBL_BANKALAR where ID=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtID.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listele();
                    temizle();
                    MessageBox.Show("Firma Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                // Eğer kullanıcı 'Hayır' cevabını verirse, işlem yapma
                else if (result == DialogResult.No)
                {
                    // Hiçbir şey yapma
                }

            }
        }
    }
}
