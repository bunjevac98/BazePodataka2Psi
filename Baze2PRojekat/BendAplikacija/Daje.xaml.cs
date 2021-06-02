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
    /// Interaction logic for Daje.xaml
    /// </summary>
    public partial class Daje : Window
    {
        public Daje()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        
        private void Add_Click(object sender, RoutedEventArgs e) {
            int b = Int32.Parse(TextBoxIDFestivala.Text);
            int c = Int32.Parse(TextBoxIDNagrade.Text);

            if (TextBoxIDFestivala.Text != "" && TextBoxIDNagrade.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Dajes([FestivalIdF],[NagradaIdNag]) VALUES(" + b + "," + c + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    UcitajDajes();
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
            int b = Int32.Parse(TextBoxIDFestivala.Text);
            int c = Int32.Parse(TextBoxIDNagrade.Text);
            if (TextBoxIDFestivala.Text != "" && TextBoxIDNagrade.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Dajes SET FestivalIdF=" +
                    b + ",NagradaIdNag=" + c + " WHERE FestivalIdF =" + PamtiKljucFestivalaDajes + " and NagradaIdNag=" + PamtiKljucNagrade + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    UcitajDajes();
                }
                catch (Exception)
                {
                    MessageBox.Show("Niste dobre kljuceve uneli od festivala ili nagrade");
                }
            }
            else {
                MessageBox.Show("Niste uneli sva polja");
            }



        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Dajes WHERE FestivalIdF=" + PamtiKljucFestivalaDajes + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                con.Close();
                UcitajDajes();
            }
            catch (Exception)
            {
                MessageBox.Show("Niste OBRISALI DOBRO");
            }






        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Dajes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridDajes.ItemsSource = ds.Tables[0].DefaultView;
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
        public void UcitajDajes() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Dajes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridDajes.ItemsSource = ds.Tables[0].DefaultView;
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


        public static int PamtiKljucNagrade;
        public static int PamtiKljucFestivalaDajes;

        private void DataGridDajes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                // kljuc = Int32.Parse(dr["IdF"].ToString());
                TextBoxIDFestivala.Text = dr["FestivalIdF"].ToString();
                TextBoxIDNagrade.Text = dr["NagradaIdNag"].ToString();
                PamtiKljucNagrade = Int32.Parse(dr["NagradaIdNag"].ToString());
                PamtiKljucFestivalaDajes = Int32.Parse(dr["FestivalIdF"].ToString());


            }


        }
    }
}
