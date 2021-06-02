using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;




namespace BendAplikacija
{
    class SQLServerConnections
    {
        public static string GetConnectionStrings() {
            
            string strConString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return strConString;
        }
        
       
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("",con);
        
        
        public static void openConnection() {
            try
            {
                if (con.State == ConnectionState.Closed) {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SISTEM NIJE USPEO DA STAVI KONEKCIJU"+ Environment.NewLine+"DESCTIPTION"+ ex.Message.ToString(),"C# WPF to SQL SERVER", MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        public static void closeConnection() {

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    
                    con.Close();
                }


            }
            catch (Exception)
            {

                throw;
            }




        }



    }
}
