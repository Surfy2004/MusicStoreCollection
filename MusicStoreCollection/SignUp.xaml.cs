using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace MusicStoreCollection
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=DESKTOP-LB7K2DP\SQLEXPRESS;Initial Catalog=MusicStore;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                string query = "Insert into UserInfo (Username, Password,Email) values ('" +Username.Text+ "','" +Password.Text+ "', '" +Email.Text+ "')";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                HomePage dashboard = new HomePage();
                dashboard.welcome_Copy.Content = $"{Username.Text}";
                dashboard.Show();
                this.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                sqlCon.Close();
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            StartingPage lg = new StartingPage();
            lg.Show();
            this.Close();
        }
    }
}
