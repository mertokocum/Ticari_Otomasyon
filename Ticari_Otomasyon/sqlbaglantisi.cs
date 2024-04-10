using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace Ticari_Otomasyon
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source = DESKTOP-KH7LR7T\SQLEXPRESS; Initial Catalog = DboTicariOtomasyon; Integrated Security = True;");
            baglan.Open();
            return baglan;
        }
    }
}
