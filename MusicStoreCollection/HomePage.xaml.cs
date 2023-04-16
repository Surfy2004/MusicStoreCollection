using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rock dashboard = new Rock();
            dashboard.Hi_Copy.Content = $"{welcome_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Pop dashboard = new Pop();
            dashboard.Hi_Copy.Content = $"{welcome_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Rap dashboard = new Rap();
            dashboard.Hi_Copy.Content = $"{welcome_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=DESKTOP-LB7K2DP\SQLEXPRESS;Initial Catalog=MusicStore;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                string query = "select Song, Artist, Genre from MusicInfo left join RecordHolder1 on RecordHolder1.Record_Id = MusicInfo.SongId left join UserInfo on  RecordHolder1.Holder_Id = UserInfo.Id  where UserInfo.Username = @Username";
                string query2 = "select Id from UserInfo where UserInfo.Username = @Username";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.CommandType = CommandType.Text;
                SqlCommand cmd1 = new SqlCommand(query2, sqlCon);
                cmd1.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", welcome_Copy.Content);
                cmd.ExecuteNonQuery();
                cmd1.Parameters.AddWithValue("@Username", welcome_Copy.Content);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGrid_.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {

                    yourid.Content = reader["Id"].ToString();
                }
                reader.Close();
                sqlCon.Close();
                
            }
            catch (Exception ex)
            {

            }

        }
    }
}
