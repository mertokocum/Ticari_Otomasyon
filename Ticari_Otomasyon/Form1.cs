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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.FormClosed += Fr_FormClosed; // FormClosed olayına bir event handler ekleyin.
                fr.Show();
            }
            else
            {
                // Form zaten açık ise, kullanıcıya odaklan.
                fr.Activate();
            }
        }
        private void Fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr.FormClosed -= Fr_FormClosed; // EventHandler'ı kaldırın, böylece çöp toplayıcı nesneyi temizleyebilir.
            fr = null; // fr nesnesini null yaparak bir sonraki açılışta yeniden oluşturulmasını sağlayın.
        }
    }
}
