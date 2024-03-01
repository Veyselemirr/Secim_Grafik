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

namespace WindowsFormsApp1
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2K9PCLA;Initial Catalog=DbSecim;Integrated Security=True;");
        private void BtnOygiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Ilce (IlceAd,A_Parti,B_Parti,C_Parti,D_Parti,E_Parti) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtIlce.Text);
            komut.Parameters.AddWithValue("@p2", TxtA.Text);
            komut.Parameters.AddWithValue("@p3", TxtB.Text);
            komut.Parameters.AddWithValue("@p4", TxtC.Text);
            komut.Parameters.AddWithValue("@p5", TxtD.Text);
            komut.Parameters.AddWithValue("@p6", TxtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
            this.Hide();
        }
    }
}
