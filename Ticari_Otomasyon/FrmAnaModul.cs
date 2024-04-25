﻿using System;
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

    }
}
