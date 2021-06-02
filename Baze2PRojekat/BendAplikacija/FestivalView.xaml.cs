using Baze2PRojekat;
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
    /// Interaction logic for FestivalView.xaml
    /// </summary>
    public partial class FestivalView : Window
    {
        public FestivalView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();






        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TextBoxNazivF.Text;
            string c = TextBoxMestoOdr.Text;

            if (TextBoxNazivF.Text != "" && TextBoxMestoOdr.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Festivals([NazF],[ModrzF]) VALUES('" + b + "','" + c + "')", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    UcitajFestivale();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo uspeli dodati");
                    con.Close();
                }
               
            }
            else {
                MessageBox.Show("Niste uneli sva polja");
            }


        }
       
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNazivF.Text != "" && TextBoxMestoOdr.Text != "")
            {
                try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("UPDATE dbo.Festivals SET NazF='" +
                TextBoxNazivF.Text + "',ModrzF='" + TextBoxMestoOdr.Text + "'WHERE IdF =" + kljuc + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);

                con.Close();
                UcitajFestivale();
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Festivals WHERE IdF=" + kljuc + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                con.Close();
                UcitajFestivale();
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli Delete");
                con.Close();
            }
            
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Festivals", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridFestivali.ItemsSource = ds.Tables[0].DefaultView;
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

        public void UcitajFestivale() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Festivals", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridFestivali.ItemsSource = ds.Tables[0].DefaultView;
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


        public static int kljuc;
        private void DataGridFestivali_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["IdF"].ToString());
                TextBoxNazivF.Text = dr["NazF"].ToString();
                TextBoxMestoOdr.Text = dr["ModrzF"].ToString();

            }



        }











    }
}
