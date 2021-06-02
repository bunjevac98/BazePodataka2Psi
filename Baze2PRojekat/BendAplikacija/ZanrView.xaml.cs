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
    /// Interaction logic for ZanrView.xaml
    /// </summary>
    public partial class ZanrView : Window
    {
        public ZanrView()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();






        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string a = Naziv.Text;
            

            if (Naziv.Text != "" )
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Zanrs([Naziv]) VALUES('" + a + "')", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    UcitajZanr();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kljucevi nisu Dobri");
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
                if (Naziv.Text != "")
                {
                    try
                    {
                        con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Zanrs SET Naziv='" + Naziv.Text +  "'WHERE Idz =" + kljucZanr + "", con);
                    DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(ds);

                        con.Close();
                        UcitajZanr();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nismo uspeli Update");
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Zanrs WHERE Idz=" + kljucZanr + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                con.Close();
                UcitajZanr();
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Zanrs", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridZanr.ItemsSource = ds.Tables[0].DefaultView;
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
        public void UcitajZanr() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Zanrs", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridZanr.ItemsSource = ds.Tables[0].DefaultView;
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


        public static int kljucZanr;
        private void DataGridZanr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljucZanr = Int32.Parse(dr["Idz"].ToString());
                Naziv.Text = dr["Naziv"].ToString();
                

            }





        }









    }
}
