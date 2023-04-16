using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MusicStoreCollection
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
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
                string query = "SELECT COUNT(1) FROM UserInfo Where Username=@Username and Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                sqlCmd.Parameters.AddWithValue("@Password", Password.Text);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    HomePage dashboard = new HomePage();
                    dashboard.welcome_Copy.Content = $"{Username.Text}";
                    dashboard.Show(); 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password are not correct!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
