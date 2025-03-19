using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler fr1;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new FrmUrunler();
                fr1.MdiParent = this;
                fr1.FormClosed += Fr1_FormClosed; // FormClosed olayına bir event handler ekleyin.
                fr1.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr1.Activate();
            }
        }
        private void Fr1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr3 değişkenini null olarak ayarla
            fr1 = null;
        }

        FrmMusteriler fr2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.FormClosed += Fr2_FormClosed; // FormClosed olayına bir event handler ekleyin.
                fr2.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr2.Activate();
            }
        }
        private void Fr2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr3 değişkenini null olarak ayarla
            fr2 = null;
        }

        FrmFirmalar fr3;
        
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this;
                fr3.FormClosed += Fr3_FormClosed; // Form kapatıldığında olayı yakala
                fr3.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr3.Activate();
            }
        }

        private void Fr3_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr3 değişkenini null olarak ayarla
            fr3 = null;
        }

        FrmPersonel fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmPersonel();
                fr4.MdiParent = this;
                fr4.FormClosed += Fr4_FormClosed; // Form kapatıldığında olayı yakala
                fr4.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr4.Activate();
            }
        }
        private void Fr4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr3 değişkenini null olarak ayarla
            fr4 = null;
        }

        FrmRehber fr5;

        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.FormClosed += Fr5_FormClosed; // Form kapatıldığında olayı yakala
                fr5.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr5.Activate();
            }
        }
        private void Fr5_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr5 değişkenini null olarak ayarla
            fr5 = null;
        }

        FrmGiderler fr6;

        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this;
                fr6.FormClosed += Fr6_FormClosed; // Form kapatıldığında olayı yakala
                fr6.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr6.Activate();
            }
        }
        private void Fr6_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr6 değişkenini null olarak ayarla
            fr6 = null;
        }

        FrmBankalar fr7;

        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this;
                fr7.FormClosed += Fr7_FormClosed; // Form kapatıldığında olayı yakala
                fr7.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr7.Activate();
            }
        }
        private void Fr7_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında fr6 değişkenini null olarak ayarla
            fr7 = null;
        }
    }
}
