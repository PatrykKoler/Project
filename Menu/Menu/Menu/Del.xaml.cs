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
using System.Data.SqlClient;

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
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string Delete = getDelete.Text;


            if (Delete == "")
                MessageBox.Show("Musisz podać wartości");
            else
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn.ConnectionString = "server = .\\SQLEXPRESS;" +
                                      "Trusted_Connection = yes;" +
                                      "database = Paliwo;";


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM Expenses WHERE id = " + Delete + "";
                cmd.Connection = sqlConn;

                sqlConn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Wpis został usuniety pomyślnie :)");
                sqlConn.Close();
            }
        }

    }
}
