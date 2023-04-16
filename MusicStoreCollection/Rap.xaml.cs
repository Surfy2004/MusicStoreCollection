using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Runtime.Remoting.Messaging;

namespace MusicStoreCollection
{
    /// <summary>
    /// Interaction logic for Rap.xaml
    /// </summary>
    public partial class Rap : Window
    {
        public Rap()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rock dashboard = new Rock();
            dashboard.Hi_Copy.Content = $"{Hi_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pop dashboard = new Pop();
            dashboard.Hi_Copy.Content = $"{Hi_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HomePage dashboard = new HomePage();
            dashboard.welcome_Copy.Content = $"{Hi_Copy.Content}";
            dashboard.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=DESKTOP-LB7K2DP\SQLEXPRESS;Initial Catalog=MusicStore;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                string query = "Insert into RecordHolder1(Username, Record_Id, Holder_Id) values (@Username, @Number, @Holder)";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                int userVal = int.Parse(Number.Text);
                cmd.Parameters.AddWithValue("@Number", userVal);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", Hi_Copy.Content);
                cmd.Parameters.AddWithValue("@Holder", Holder.Text);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=DESKTOP-LB7K2DP\SQLEXPRESS;Initial Catalog=MusicStore;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                string query = "select SongId, Song, Artist from MusicInfo where MusicInfo.Genre = 'Rap'";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGridPop.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                sqlCon.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
