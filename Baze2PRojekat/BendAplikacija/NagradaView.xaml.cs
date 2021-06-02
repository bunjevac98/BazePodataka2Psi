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
    /// Interaction logic for NagradaView.xaml
    /// </summary>
    public partial class NagradaView : Window
    {
        public NagradaView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TextBoxNazNag.Text;
            
            if (TextBoxNazNag.Text != "" )
            {
                con.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO dbo.Nagradas([NazNag]) VALUES('" + b + "')", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);

                con.Close();
                UcitajNagrade();
            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }








        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE dbo.Nagradas SET NazNag='" +
            TextBoxNazNag.Text + "'WHERE IdNag =" + kljuc + "", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            con.Close();
            UcitajNagrade();

        }








        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM dbo.Nagradas WHERE IdNag=" + kljuc + "", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            con.Close();
            UcitajNagrade();





        }


        public static int kljuc;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Nagradas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridNagrada.ItemsSource = ds.Tables[0].DefaultView;
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
        public void UcitajNagrade() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Nagradas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridNagrada.ItemsSource = ds.Tables[0].DefaultView;
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

        private void DataGridNagrada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["IdNag"].ToString());
                TextBoxNazNag.Text = dr["NazNag"].ToString();

            }
        }








    }
}
