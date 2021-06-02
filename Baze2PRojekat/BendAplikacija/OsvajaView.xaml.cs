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
    /// Interaction logic for OsvajaView.xaml
    /// </summary>
    public partial class OsvajaView : Window
    {
        public OsvajaView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void Add_Click(object sender, RoutedEventArgs e) {
            int a = Int32.Parse(TextBoxUcestvujeIdBenda.Text);
            int b = Int32.Parse(TextBoxUcestvujeIdFestivala.Text);
            int c = Int32.Parse(TextBoxDajeIdFestival.Text);
            int d = Int32.Parse(TextBoxDajeNagrada.Text);
            //mozda ako festival id nije isti proveriti isto
            if (TextBoxUcestvujeIdBenda.Text != "" && TextBoxUcestvujeIdFestivala.Text != "" && TextBoxDajeIdFestival.Text != "" && TextBoxDajeNagrada.Text != "" && TextBoxUcestvujeIdFestivala.Text == TextBoxDajeIdFestival.Text)
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Osvajas([UcestvujeBendIdBenda],[UcestvujeFestivalIdf],[DajeFestivalIdF],[DajeNagradaIdNag]) VALUES(" + a + "," + b +","+ c + "," + d + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kljucevi koje ste uneli nisu dobri");
                    con.Close();//Proveriti
                }

            }
            else
            {
                MessageBox.Show("Niste uneli sva polja ili vam kljuc festivala nije dobar");
            }




        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(TextBoxUcestvujeIdBenda.Text);
            int b = Int32.Parse(TextBoxUcestvujeIdFestivala.Text);
            int c = Int32.Parse(TextBoxDajeIdFestival.Text);
            int d = Int32.Parse(TextBoxDajeNagrada.Text);

            if (TextBoxUcestvujeIdBenda.Text != "" && TextBoxUcestvujeIdFestivala.Text != "" && TextBoxDajeIdFestival.Text != "" && TextBoxDajeNagrada.Text != "" && TextBoxUcestvujeIdFestivala.Text == TextBoxDajeIdFestival.Text)
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Osvajas SET UcestvujeBendIdBenda=" +
                    a + ",UcestvujeFestivalIdf=" + b + ",DajeFestivalIdF="+c+ ",DajeNagradaIdNag="+d+
                    " WHERE UcestvujeBendIdBenda =" + pamtiKljucUcestvujeIdBenda + " and UcestvujeFestivalIdf=" + pamtiKljucUcestvujeIdFestivala +
                    "and DajeFestivalIdF="  + pamtiKljucDajeIdBenda + "and DajeNagradaIdNag="+ pamtiKljucDajeIdNagrada + "" , con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kljucevi koje ste uneli nisu dobri ili se Festival id kljucevi ne poklapaju");
                    con.Close();//Proveriti
                }
            }
            }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Osvajas WHERE UcestvujeBendIdBenda=" + pamtiKljucUcestvujeIdBenda + "", con);
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Osvajas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridOsvaja.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Osvajas", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DataGridOsvaja.ItemsSource = ds.Tables[0].DefaultView;
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

        public static int pamtiKljucUcestvujeIdBenda;
        public static int pamtiKljucUcestvujeIdFestivala;
        public static int pamtiKljucDajeIdBenda;
        public static int pamtiKljucDajeIdNagrada;

        private void DataGridOsvaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                // kljuc = Int32.Parse(dr["IdF"].ToString());
                TextBoxUcestvujeIdBenda.Text =dr["UcestvujeBendIdBenda"].ToString();
                TextBoxUcestvujeIdFestivala.Text =dr["UcestvujeFestivalIdf"].ToString();
                TextBoxDajeIdFestival.Text = dr["DajeFestivalIdF"].ToString();
                TextBoxDajeNagrada.Text = dr["DajeNagradaIdNag"].ToString();

                pamtiKljucUcestvujeIdBenda = Int32.Parse(TextBoxUcestvujeIdBenda.Text);
                pamtiKljucUcestvujeIdFestivala = Int32.Parse(TextBoxUcestvujeIdFestivala.Text);
                pamtiKljucDajeIdBenda = Int32.Parse(TextBoxDajeIdFestival.Text);
                pamtiKljucDajeIdNagrada = Int32.Parse(TextBoxDajeNagrada.Text);




            }




        }
    }
}
