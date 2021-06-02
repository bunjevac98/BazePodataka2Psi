﻿using System;
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
    /// Interaction logic for MenadzerView.xaml
    /// </summary>
    public partial class MenadzerView : Window
    {
        public MenadzerView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string b = TBImeMen.Text;
            int c = Int32.Parse(TBIDBenda.Text);

            if (TBImeMen.Text != "" && TBIDBenda.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO dbo.Menadzers([ImeMen],[BendIdBenda]) VALUES('" + b + "'," + c + ")", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo uspeli dodati Nemamo bend sa tim ID");
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
            if (TBImeMen.Text != "" && TBIDBenda.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("UPDATE dbo.Menadzers SET ImeMen='" +
                    TBImeMen.Text + "',BendIdBenda=" + TBIDBenda.Text + "WHERE IdMen =" + kljuc + "", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);

                    con.Close();
                    Ucitaj();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nismo supeli Update Nemamo Bend sa Tim id");
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
                SqlCommand comm = new SqlCommand("DELETE FROM dbo.Menadzers WHERE IdMen=" + kljuc + "", con);
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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Menadzers", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DGMEnadzer.ItemsSource = ds.Tables[0].DefaultView;
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
                SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Menadzers", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                DGMEnadzer.ItemsSource = ds.Tables[0].DefaultView;
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

        private void DGMEnadzer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {
                kljuc = Int32.Parse(dr["IdMen"].ToString());
                TBImeMen.Text = dr["ImeMen"].ToString();
                TBIDBenda.Text = dr["BendIdBenda"].ToString();

            }
        }










    }
}
