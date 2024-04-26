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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        private sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtID.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
            TxtMail.Text = "";
            TxtSektor.Text = "";
            TxtVergi.Text = "";
            TxtYetkili.Text = "";
            TxtYetkiliGorev.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTelefon3.Text = "";
            MskFax.Text = "";
            MskYetkiliTC.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            //RchKod1.Text = "";
            //RchKod2.Text = "";
            //RchKod3.Text = "";
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

        void carikodaciklamalar()
        {
            SqlCommand komut1 = new SqlCommand("Select FIRMAKOD1 from Tbl_kodlar", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                RchKod1.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();
            SqlCommand komut2 = new SqlCommand("Select FIRMAKOD2 from Tbl_kodlar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                RchKod2.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();
            SqlCommand komut3 = new SqlCommand("Select FIRMAKOD3 from Tbl_kodlar", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                RchKod3.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();

        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();
            sehirlistesi();
            carikodaciklamalar();
            temizle();
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


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MskYetkiliTC.Text = dr["YETKILITC"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
                MskTelefon1.Text = dr["TELEFON1"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTelefon3.Text = dr["TELEFON3"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtKod1.Text = dr["OZELKOD1"].ToString();
                TxtKod2.Text = dr["OZELKOD2"].ToString();
                TxtKod3.Text = dr["OZELKOD3"].ToString();
                

            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut =
                new SqlCommand(
                    "insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3 ) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)",
                    bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@P3", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@P4", MskYetkiliTC.Text);
            komut.Parameters.AddWithValue("@P5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@P6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@P7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@P8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@P9", TxtMail.Text);
            komut.Parameters.AddWithValue("@P10", MskFax.Text);
            komut.Parameters.AddWithValue("@P11", Cmbil.Text);
            komut.Parameters.AddWithValue("@P12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@P13", TxtVergi.Text);
            komut.Parameters.AddWithValue("@P14", RchAdres.Text);
            komut.Parameters.AddWithValue("@P15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@P16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@P17", TxtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firmalistesi();
            temizle();
            MessageBox.Show("Firma Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }
    }
}
