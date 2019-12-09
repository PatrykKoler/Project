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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public Edit()
        {
            InitializeComponent();
            Filldate();
        }
        void Filldate()
        {
            DateTime Date = DateTime.Today;
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {

            string Date = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            //SqlConnection sqlConn = new SqlConnection();
            //sqlConn.ConnectionString = "server = .\\SQLEXPRESS;" +
            //                          "Trusted_Connection = yes;" +
            //                          "database = Paliwo;";

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            sqlConn.Open();

            List<Expenses> listid = new List<Expenses>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select id, Amount, Liters, CAST(CAST (Date_added as date) as varchar(10)) date_Added, GETDATE() as date_Modification  from Expenses WHERE date_added = '" + Date + "'";
            cmd.Connection = sqlConn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Expenses oil = new Expenses();

                oil.id = dr["id"].ToString();
                oil.Amount = dr["Amount"].ToString();
                oil.Liters = dr["Liters"].ToString();
                oil.Date_added = dr["date_Added"].ToString();
                oil.Date_modification = dr["date_Modification"].ToString();
                listid.Add(oil);
            }
            getLiters.Text = listid.FirstOrDefault().Liters;
            getAmount.Text = listid.FirstOrDefault().Amount;
            dr.Close();
            table.ItemsSource = listid;

            sqlConn.Close();

           
        }

        private void getAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void getLiters_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //private  void  Edited_Click(object sender, RoutedEventArgs e)
        //{


        //            decimal Amount1 = decimal.Parse(Amount);

        //            string AmountString = Amount1.ToString(System.Globalization.CultureInfo.InvariantCulture);

        //            SqlConnection sqlConn = new SqlConnection();
        //            sqlConn.ConnectionString = "server = .\\SQLEXPRESS;" +
        //                                       "database = Paliwo ;" +
        //                                       "User Id = wgrala;" +
        //                                       "Password = otto";

        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = "UPDATE Expenses SET Amount = " + AmountString + " WHERE id = " + id + "";
        //            cmd.Connection = sqlConn;

        //            sqlConn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Wpis został edytowany pomyślnie :)");
        //            sqlConn.Close();

        //}
    }
}
