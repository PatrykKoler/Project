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
    /// Interaction logic for Del.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
            dowloandRekords();
        }
        void dowloandRekords()

        {           
            
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sqlConn.Open();

            List<Expenses> listid = new List<Expenses>();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = "SELECT id, Amount, Liters, CAST(CAST (Date_added as date) as varchar(10)) date_added,  CAST(date_Modification as varchar(19)) date_Modification  FROM Expenses where status = 1";
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

            sqlConn.Open();
            List<Expenses> listAmount = new List<Expenses>();
                        
            SqlCommand Coin = new SqlCommand();
            Coin.CommandText = "select sum(Amount) AS Kwota from Expenses where Date_added >= DATEADD ( dd,-DAY( GETDATE()-1 ), GETDATE() ) and Date_added <= DATEADD(mm,1,DATEADD(dd,-(DAY(getdate())-1), getdate()) )-1 AND status = 1;";
            Coin.Connection = sqlConn;

            SqlDataReader sumDr = Coin.ExecuteReader();
            while (sumDr.Read())
            {
                Expenses sum = new Expenses();
                
                sum.Amount = sumDr["Kwota"].ToString();
                                
                listAmount.Add(sum);
            }
            sumDr.Close();
            
            sqlConn.Close();
            if (listAmount.Count == 0)
                showCoinsOfMonth.Content = "0 zł";
            else                
                showCoinsOfMonth.Content = "" + listAmount.FirstOrDefault().Amount + " zł";

            sqlConn.Open();
            List<Expenses> listAmountYear = new List<Expenses>();

            SqlCommand CoinOfYear = new SqlCommand();
            CoinOfYear.CommandText = "select sum(Amount) as Kwota from Expenses where Date_added >= DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) - 1, 0) and Date_added <=  DATEADD (dd, -1, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) +1, 0)) AND status = 1;";
            CoinOfYear.Connection = sqlConn;

            SqlDataReader sumDrYear = CoinOfYear.ExecuteReader();
            while (sumDrYear.Read())
            {
                Expenses sum = new Expenses();

                sum.Amount = sumDrYear["Kwota"].ToString();

                listAmountYear.Add(sum);
            }
            sumDrYear.Close();
            sqlConn.Close();
            if(listAmountYear.Count == 0)
                showCoinsOfYear.Content = "0 zł";
            else
                showCoinsOfYear.Content = "" + listAmountYear.FirstOrDefault().Amount + " zł";

        }

    }
}
