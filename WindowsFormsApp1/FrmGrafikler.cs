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
    public partial class FrmGrafikler : Form
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2K9PCLA;Initial Catalog=DbSecim;Integrated Security=True;");

        public FrmGrafikler()
        {
            InitializeComponent();
        }

        

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select IlceAd from Tbl_Ilce", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(A_Parti),SUM(B_Parti),Sum(C_Parti),Sum(D_Parti),Sum(E_Parti) from Tbl_Ilce", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) { 
            chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
            chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
            chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
            chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
            chart1.Series["Partiler"].Points.AddXY("E Parti", dr2[4]);
            }
            baglanti.Close() ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ilce where IlceAd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                LblA.Text = dr[2].ToString();
                LblB.Text = dr[3].ToString();
                LblC.Text   = dr[4].ToString();
                LblD.Text= dr[5].ToString();
                LblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
