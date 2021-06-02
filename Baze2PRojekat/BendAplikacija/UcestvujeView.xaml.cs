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
    /// Interaction logic for UcestvujeView.xaml
    /// </summary>
    public partial class UcestvujeView : Window
    {

        public UcestvujeView()
        {
            InitializeComponent();
            
           
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxIdBenda.Text != "" && TextBoxIdF.Text != "")
            {
                int b = Int32.Parse(TextBoxIdBenda.Text);
                int c = Int32.Parse(TextBoxIdF.Text);
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Ucestvujes([BendIdBenda],[FestivalIdf]) VALUES(" + b + "," + c + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    UcitajUcestvovanja();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nemamo taj kljuc u Bendu ili festivalu");
                    con.Close();//PROVERITI
                }
                
            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }





        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxIdBenda.Text != "" && TextBoxIdF.Text != "")
            {
                int b = Int32.Parse(TextBoxIdBenda.Text);
                int c = Int32.Parse(TextBoxIdF.Text);


                con.Open();
                SqlCommand comm = new SqlCommand("UPDATE dbo.Ucestvujes SET BendIdBenda=" +
                b + ",FestivalIdf=" + c + "WHERE FestivalIdf =" + PamtiKljucFestivala + " and BendIdBenda=" + PamtiKljucBenda + "", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);

                con.Close();
                UcitajUcestvovanja();
            }
            else
            {
                MessageBox.Show("Niste uneli sva polja");
            }


        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM dbo.Ucestvujes WHERE BendIdBenda=" + PamtiKljucBenda + " and FestivalIdf=" + PamtiKljucFestivala + "", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            con.Close();
            UcitajUcestvovanja();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Ucestvujes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridUcestvuje.ItemsSource = ds.Tables[0].DefaultView;
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

        public void UcitajUcestvovanja() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Ucestvujes", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridUcestvuje.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispisemo(Ucestvuje) ");
            }
            finally
            {
                con.Close();

            }


        }


        public static int PamtiKljucBenda;
        public static int PamtiKljucFestivala;
        private void DataGridUcestvuje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
               // kljuc = Int32.Parse(dr["IdF"].ToString());
                TextBoxIdBenda.Text = dr["BendIdBenda"].ToString();
                TextBoxIdF.Text = dr["FestivalIdf"].ToString();
                PamtiKljucBenda=Int32.Parse(dr["BendIdBenda"].ToString());
                PamtiKljucFestivala =Int32.Parse(dr["FestivalIdf"].ToString());


            }
        }
    }
}
