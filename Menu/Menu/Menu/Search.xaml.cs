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
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }
        private void Download_Click(object sender, RoutedEventArgs e)

        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "server = .\\SQLEXPRESS;" +
                                       "database = Paliwo ;" +
                                       "User Id= wgrala;" +
                                       "Password= otto";
            sqlConn.Open();

            List<Expenses> listid = new List<Expenses>();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "SELECT id, Amount, Liters, CAST(CAST (Date_added as date) as varchar(10)) date_added, GETDATE() as Date_modification FROM Expenses";
            sqlCmd.Connection = sqlConn;

            SqlDataReader dr = sqlCmd.ExecuteReader();
            while (dr.Read())
            {
                Expenses oil = new Expenses();
                oil.id = dr["id"].ToString();
                oil.Amount = dr["Amount"].ToString();
                oil.Liters = dr["Liters"].ToString();
                oil.Date_added = dr["Date_added"].ToString();
                oil.Date_modification = dr["Date_modification"].ToString();
                listid.Add(oil);
            }
            dr.Close();
            table.ItemsSource = listid;

            sqlConn.Close();

        }

    }
}
