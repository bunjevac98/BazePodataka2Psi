using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BendAplikacija
{
    /// <summary>
    /// Interaction logic for KoncertView.xaml
    /// </summary>
    public partial class KoncertView : Window
    {
        public KoncertView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string a = TBNazKon.Text;
            string b = TBMESTOKON.Text;
            string c = TBDATUM.Text;

            if (TBNazKon.Text != "" && TBMESTOKON.Text != "" && TBDATUM.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Koncerts([NazKon],[MoKon],[DatumKon]) VALUES('" + a + "','" + b + "','" + c +"')", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U FESTIVALU ILI NAGRADI");
                    con.Close();//Proveriti
                }

            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }




        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
            if (TBNazKon.Text != "" && TBMESTOKON.Text != "" && TBDATUM.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Koncerts SET NazKon='" +
                    TBNazKon.Text + "',MoKon='" + TBMESTOKON.Text +"',DatumKon='"+ TBDATUM.Text + "'WHERE IdKon =" + PamtiKljuc + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo updejtovali");
                    con.Close();//Proveriti
                }

            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }








        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Koncerts WHERE IdKon=" + PamtiKljuc + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                con.Close();
                Ucitaj();
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli Delete");
                con.Close();
            }





        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Koncerts", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridKoncert.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispisemo");
            }
            finally
            {
                con.Close();

            }
        }
        public void Ucitaj() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Koncerts", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridKoncert.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispisemo");
            }
            finally
            {
                con.Close();

            }


        }


        public static int PamtiKljuc;

        private void DataGridKoncert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                PamtiKljuc = Int32.Parse(dr["IdKon"].ToString());
                TBNazKon.Text = dr["NazKon"].ToString();
                TBMESTOKON.Text = dr["MoKon"].ToString();
                TBDATUM.Text = dr["DatumKon"].ToString();
                

            }





        }
    }
}
