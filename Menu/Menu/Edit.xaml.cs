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
        }
               
        private void Show_Click(object sender, RoutedEventArgs e)
        {
                     
            if (this.selectDate.Text == "")
            {
                MessageBox.Show("Musisz podać datę");
            }

            else
            {
                string Date = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");

                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                sqlConn.Open();

                List<Expenses> listid = new List<Expenses>();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select id, Amount, Liters, CAST(CAST (Date_added as date) as varchar(10)) date_Added, CAST (date_Modification as varchar(19)) date_Modification from Expenses WHERE date_added = '" + Date + "' AND status = 1;";
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
                dr.Close();
                table.ItemsSource = listid;
                if (listid.Count == 0)
                {
                    MessageBox.Show("Nie ma żadnych wpis z tego dnia :(");
                }
                else
                {
                    getLiters.Text = listid.FirstOrDefault().Liters;
                    getAmount.Text = listid.FirstOrDefault().Amount;
                }

                sqlConn.Close();              
                                
            }
        }


        private void Edited_Click(object sender, RoutedEventArgs e)
        {            
            string Date = selectDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            string Amount = getAmount.Text;
            string Liters = getLiters.Text;

            if (Amount == "" || Liters == "")
                MessageBox.Show("Musisz podac wartość :)");
            else
            {
                decimal Amount1 = decimal.Parse(Amount);
                decimal Liters1 = decimal.Parse(Liters);
                                
                string AmountString = Amount1.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string LitersString = Liters1.ToString(System.Globalization.CultureInfo.InvariantCulture);
                
                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Expenses SET Amount = " + AmountString + ", Liters = " + LitersString + ",  date_modification = GETDATE() WHERE date_added = '" + Date + "';";
                cmd.Connection = sqlConn;

                sqlConn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Wpis został edytowany pomyślnie :)");
                sqlConn.Close();
            }   
            

        }

        
    }
}
