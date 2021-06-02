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
    /// Interaction logic for SnimaView.xaml
    /// </summary>
    public partial class SnimaView : Window
    {
        public SnimaView()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(TBIDBenda.Text);
            int b = Int32.Parse(TBAlbuma.Text);

            if (TBIDBenda.Text != "" && TBAlbuma.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Snimas([BendIdBenda],[AlbumIdAlb]) VALUES(" + a + "," + b + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ALBUMU ILI BENDU");
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
            int a = Int32.Parse(TBIDBenda.Text);
            int b = Int32.Parse(TBAlbuma.Text);

            if (TBIDBenda.Text != "" && TBAlbuma.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Snimas SET BendIdBenda=" +
                    a + ",AlbumIdAlb=" + b + " WHERE BendIdBenda =" + pamtiKljucBenda + " and AlbumIdAlb=" + pamtiKljucAlbuma + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ALBUMA ILI BENDU");
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
            //Mozda treba and i drugi kljuc da mu prosledim ali nelogicno mozda???
            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Snimas WHERE BendIdBenda=" + pamtiKljucBenda + " and AlbumIdAlb=" + pamtiKljucAlbuma + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                con.Close();
                Ucitaj();
            }
            catch (Exception)
            {
                MessageBox.Show("Niste OBRISALI DOBRO");
            }




        }





        public static int pamtiKljucBenda;
        public static int pamtiKljucAlbuma;


        private void DATAGRIDSnima_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                
                TBIDBenda.Text = dr["BendIdBenda"].ToString();
                TBAlbuma.Text = dr["AlbumIdAlb"].ToString();
                pamtiKljucBenda = Int32.Parse(dr["BendIdBenda"].ToString());
                pamtiKljucAlbuma = Int32.Parse(dr["AlbumIdAlb"].ToString());


            }




        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Snimas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DATAGRIDSnima.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Snimas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DATAGRIDSnima.ItemsSource = ds.Tables[0].DefaultView;
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






    }
}
