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
    /// Interaction logic for MuzickaKucaView.xaml
    /// </summary>
    public partial class MuzickaKucaView : Window
    {
        public MuzickaKucaView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TBNAZMIK.Text;
            string c = TBADRMik.Text;

            if (TBNAZMIK.Text != "" && TBADRMik.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.MuzickaIzdavackaKucas([NazMik],[AdrMik]) VALUES('" + b + "','" + c + "')", con);
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
            if (TBNAZMIK.Text != "" && TBADRMik.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.MuzickaIzdavackaKucas SET NazMik='" +
                    TBNAZMIK.Text + "',AdrMik='" + TBADRMik.Text + "'WHERE Idmik =" + kljuc + "", con);
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.MuzickaIzdavackaKucas WHERE Idmik=" + kljuc + "", con);
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
        
        private void DataGridMuzickaKuca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["Idmik"].ToString());
                TBNAZMIK.Text = dr["NazMik"].ToString();
                TBADRMik.Text = dr["AdrMik"].ToString();

            }




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.MuzickaIzdavackaKucas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridMuzickaKuca.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.MuzickaIzdavackaKucas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridMuzickaKuca.ItemsSource = ds.Tables[0].DefaultView;
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
