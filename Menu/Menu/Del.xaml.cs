using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;

namespace Menu
{
    /// <summary>
    /// Interaction logic for Del.xaml
    /// </summary>
    public partial class Del : Page
    {
        public Del()
        {
            InitializeComponent();
            fillcomb();
        }

        void fillcomb()
         
            {
             SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
             string Sql = "select id from Expenses where status = 1";

                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(Sql, sqlConn);
                SqlDataReader DR = cmd.ExecuteReader();

                while (DR.Read())
                {
                    comboDelete.Items.Add(DR[0]);
                }

                sqlConn.Close();
            }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string id = comboDelete.SelectedValue.ToString();

            
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Expenses SET status = 0,  date_modification = GETDATE() WHERE id= " + id +"";                
                cmd.Connection = sqlConn;

            sqlConn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Wpis został usuniety pomyślnie :)");
            sqlConn.Close();
                 
        }

        
    }
}
