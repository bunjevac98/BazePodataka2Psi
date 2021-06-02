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

using Baze2PRojekat;
/*
using System.Data;
using System.Data.SqlClient;
*/



namespace BendAplikacija
{
    /// <summary>
    /// Interaction logic for BendView.xaml
    /// </summary>
    public partial class BendView : Window
    {
        SqlConnection con = new SqlConnection();
        
        public BendView()
        {
            
            InitializeComponent();
            
        }
        /*
        public void updateDataGrid()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT [IdBenda], [NazB], [Logo] FROM dbo.Bends";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridBend.ItemsSource = dt.DefaultView;
            dr.Close();
            #region
           
            #endregion
        }
        */
        
        public void Window_Loaded(object sender, RoutedEventArgs e) {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT [IdBenda], [NazB], [Logo] FROM dbo.Bends", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridBend.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Nismo uspeli da ispitsemo");
            }
            finally {
                con.Close();

            }
        }
        public void Ucitaj() {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT [IdBenda], [NazB], [Logo] FROM dbo.Bends", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridBend.ItemsSource = ds.Tables[0].DefaultView;
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

        /*
        private void setConnection() {
            String connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            con = new SqlConnection(connectionString);
            try
            {
                    con.Open();   
            }
            catch (Exception ex)
            {
                MessageBox.Show("SISTEM NIJE USPEO DA STAVI KONEKCIJU" + Environment.NewLine + "DESCTIPTION" + ex.Message.ToString(), "C# WPF to SQL SERVER", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        */

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
          //  int a = Int32.Parse(TextBextIdBenda.Text);
            string b= TextBextNazB.Text;
            string c= TextBextLogo.Text;

            
                con.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO dbo.Bends([NazB],[Logo]) VALUES('"+ b + "','" + c + "')", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                
                con.Close();
                Ucitaj();
            
            /*
            DataGridBend.ItemsSource = SQLServerConnections.dt.DefaultView;


            if (TextBextIdBenda.Text != "" && TextBextNazB.Text != "" && TextBextLogo.Text != "")
            {
                String sql = "INSERT INTO dbo.Bends(IdBenda, NazB, Logo) " + " VALUES('" + Int32.Parse(TextBextIdBenda.Text) + "', '" + TextBextNazB.Text + "', '" + TextBextLogo.Text + "') ";
            }
            */
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {


            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE dbo.Bends SET NazB='" +
            TextBextNazB.Text + "',Logo='" + TextBextLogo.Text + "'WHERE IdBenda =" + kljuc + "", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);

            con.Close();
            Ucitaj();
            

        }


        public static int kljuc;
        private void DataGridBend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            
            if (dr != null)
            {
                kljuc = Int32.Parse(dr["IdBenda"].ToString());
                TextBextNazB.Text = dr["NazB"].ToString();
                TextBextLogo.Text = dr["Logo"].ToString();
                
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM dbo.Bends WHERE IdBenda=" + kljuc + "", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            con.Close();
            Ucitaj();
        }


    }










}

