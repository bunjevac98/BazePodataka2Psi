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
    /// Interaction logic for IzdajeView.xaml
    /// </summary>
    public partial class IzdajeView : Window
    {
        public IzdajeView()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(TBAlbuma.Text);
            int b = Int32.Parse(TBMik.Text);

            if (TBAlbuma.Text != "" && TBMik.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Izdajes([AlbumIdAlb],[MuzickaIzdavackaKucaIdmik]) VALUES(" + a + "," + b + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ALBUMU ILI MIK");
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
            int a = Int32.Parse(TBAlbuma.Text);
            int b = Int32.Parse(TBMik.Text);

            if (TBAlbuma.Text != "" && TBMik.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Izdajes SET AlbumIdAlb=" +
                    a + ",MuzickaIzdavackaKucaIdmik=" + b + " WHERE AlbumIdAlb =" + pamtiKljucAlbuma + " and MuzickaIzdavackaKucaIdmik=" + pamtiKljucMik + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ALBUMU ILI MIK");
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Izdajes WHERE AlbumIdAlb=" + pamtiKljucAlbuma + "and MuzickaIzdavackaKucaIdmik ="
                    + pamtiKljucMik +"", con);
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


        public static int pamtiKljucAlbuma;
        public static int pamtiKljucMik;

        private void DGIzdae_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                // kljuc = Int32.Parse(dr["IdF"].ToString());
                TBAlbuma.Text = dr["AlbumIdAlb"].ToString();
                TBMik.Text = dr["MuzickaIzdavackaKucaIdmik"].ToString();
                pamtiKljucAlbuma = Int32.Parse(dr["AlbumIdAlb"].ToString());
                pamtiKljucMik = Int32.Parse(dr["MuzickaIzdavackaKucaIdmik"].ToString());


            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Izdajes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DGIzdae.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Izdajes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DGIzdae.ItemsSource = ds.Tables[0].DefaultView;
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
