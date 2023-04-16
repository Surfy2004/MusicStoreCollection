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
using System.Windows.Shapes;

namespace MusicStoreCollection
{
    /// <summary>
    /// Interaction logic for StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Window
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            SignUp lg = new SignUp();
            lg.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            this.Close();
        }
    }
}
