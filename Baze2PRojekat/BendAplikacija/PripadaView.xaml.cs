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
    /// Interaction logic for PripadaView.xaml
    /// </summary>
    public partial class PripadaView : Window
    {
        public PripadaView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(TBIDBenda.Text);
            int b = Int32.Parse(TBZanrId.Text);

            if (TBIDBenda.Text != "" && TBZanrId.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Pripadas([BendIdBenda],[ZanrIdz]) VALUES(" + a + "," + b + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ZANRU ILI BENDU");
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
            int b = Int32.Parse(TBZanrId.Text);

            if (TBIDBenda.Text != "" && TBZanrId.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Pripadas SET BendIdBenda=" +
                    a + ",ZanrIdz=" + b + " WHERE BendIdBenda =" + pamtiKljucBenda + " and ZanrIdz=" + pamtiKljucZanra + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("NEMAMO TAJ KLJUC U ZANR ILI BENDU");
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Pripadas WHERE BendIdBenda=" + pamtiKljucBenda + "", con);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Pripadas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DAtaGridPripada.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Pripadas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DAtaGridPripada.ItemsSource = ds.Tables[0].DefaultView;
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


        public static int pamtiKljucBenda;
        public static int pamtiKljucZanra;


        private void DAtaGridPripada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                // kljuc = Int32.Parse(dr["IdF"].ToString());
                TBIDBenda.Text = dr["BendIdBenda"].ToString();
                TBZanrId.Text = dr["ZanrIdz"].ToString();
                pamtiKljucBenda = Int32.Parse(dr["BendIdBenda"].ToString());
                pamtiKljucZanra = Int32.Parse(dr["ZanrIdz"].ToString());


            }
        }
    }
}
