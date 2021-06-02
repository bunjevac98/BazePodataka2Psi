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
    /// Interaction logic for GitaristaView.xaml
    /// </summary>
    public partial class GitaristaView : Window
    {
        public GitaristaView()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();






        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TBIme.Text;
            string c = TBPrz.Text;

            if (TBIme.Text != "" && TBPrz.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Muzicars_Gitarista([ImeGitariste]]) VALUES('" + b + "')", con);
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

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Muzicars_Gitarista", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridGitarista.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Muzicars_Gitarista", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridGitarista.ItemsSource = ds.Tables[0].DefaultView;
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



        private void DataGridGitarista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["Jmbg"].ToString());
                TBIme.Text = dr["ImeGitariste"].ToString();
                TBPrz.Text = dr["Prz"].ToString();

            }
        }




    }
}
