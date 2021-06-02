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
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumView : Window
    {
        public AlbumView()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection();






        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TBNAZIVALBUMA.Text;
            string c = TBCD.Text;

            if (TBNAZIVALBUMA.Text != "" && TBCD.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Albums([NazLab],[Cd]) VALUES('" + b + "','" + c + "')", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo uspeli dodati");
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }



        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TBNAZIVALBUMA.Text != "" && TBCD.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Albums SET NazLab='" +
                    TBNAZIVALBUMA.Text + "',Cd='" + TBCD.Text + "'WHERE IdAlb =" + kljuc + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo supeli Update");
                    con.Close();
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Albums WHERE IdAlb=" + kljuc + "", con);
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


        public static int kljuc;
        private void DATAGRIDAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["IdAlb"].ToString());
                TBNAZIVALBUMA.Text = dr["NazLab"].ToString();
                TBCD.Text = dr["Cd"].ToString();

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Albums", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DATAGRIDAlbum.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispitsemo");
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Albums", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DATAGRIDAlbum.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispitsemo");
            }
            finally
            {
                con.Close();

            }


        }






    }
}
