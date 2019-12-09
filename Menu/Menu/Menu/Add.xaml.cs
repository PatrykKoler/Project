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
using System.Configuration;

namespace Menu
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }
        private void SaveRekord_Click(object sender, RoutedEventArgs e)
        {
            string Amount = getAmount.Text;
            string Liters = getLiters.Text;
            string Date = getDate.SelectedDate.Value.ToString("yyyy-MM-dd");

            if (Amount == "" || Liters == "")
                MessageBox.Show("Musisz podać wartości");
            else
            {

                decimal Amount1 = decimal.Parse(Amount);
                decimal Liters1 = decimal.Parse(Liters);

                string AmountString = Amount1.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string LitersString = Liters1.ToString(System.Globalization.CultureInfo.InvariantCulture);

                SqlConnection sqlConn = new SqlConnection();
                sqlConn.ConnectionString = "server = .\\SQLEXPRESS;" +
                                      "Trusted_Connection = yes;" +
                                      "database = Paliwo;";

                


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO Expenses (Amount, Liters, Date_added, Date_modification) " + "VALUES (" + AmountString + ", " + LitersString + ",'"+ Date + "', GETDATE())";
                cmd.Connection = sqlConn;

                sqlConn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Wpis został dodany pomyślnie :)");
                sqlConn.Close();
            }
        }
    }
}
